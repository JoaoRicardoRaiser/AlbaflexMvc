using AlbaflexMvc.Data.Entities;
using AlbaflexMvc.Data.Interfaces;
using AlbaflexMvc.Models;
using AlbaflexMvc.Services.Interfaces;
using iTextSharp.text;

namespace AlbaflexMvc.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            ILogger<ProductService> logger, 
            IProductRepository ProductRepository, 
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = ProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BudgetInformationModel> GetBudgetInformation()
        {
            var products = await _productRepository.GetAllAsync();
            var budgetInformationModel = new BudgetInformationModel
            {
                Tissues = products.Where(x => x.Type == CrossCutting.Enum.ProductType.Tecido).ToList(),
                Materials = products.Where(x => x.Type == CrossCutting.Enum.ProductType.Material).ToList(),
                CaixaBox = products.Where(x => x.Type == CrossCutting.Enum.ProductType.CaixaBox).ToList()
            };
            return budgetInformationModel;
        }

        public async Task GenerateBudgetPdf()
        {
            // Initialize document object
            Document document = new Document(PageSize.A4);
            document.SetMargins(10, 5, 10, 5);


            //// Add page
            //Page page = document.Pages.Add();

            //document.Background = Color.FromRgb(System.Drawing.Color.FromArgb(25, 25, 255));

            //// Add text to new page
            //page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));

            //// Save PDF 
            //document.Save("document.pdf");
        }

        public async Task CreateAsync(ProductInputModel model)
        {
            var productSaved = await _productRepository.GetByCodeAsync(model.Code);
            if(productSaved != null)
            {
                var message = $"Product with code {model.Code} already exists in the database.";
                _logger.LogError(message);
                throw new Exception(message);
            }

            await _productRepository.CreateAsync(new Product(model.Code, model.Description, model.Value, model.Type));

            await _unitOfWork.CommitAsync();

        }

        public async Task EditAsync(ProductInputModel model)
        {
            var productSaved = await _productRepository.GetByCodeAsync(model.Code);
            if (productSaved == null)
            {
                var message = $"Product with code {model.Code} not registred on database.";
                _logger.LogError(message);
                throw new Exception(message);
            }

            productSaved.Update(model);
            _productRepository.Update(productSaved);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int code)
        {
            var productSaved = await _productRepository.GetByCodeAsync(code);
            if(productSaved == null)
            {
                var message = $"Product with code {code} not registred on database.";
                _logger.LogError(message);
                throw new Exception(message);
            }

            _productRepository.Delete(productSaved);
            await _unitOfWork.CommitAsync();
        }
    }
}
