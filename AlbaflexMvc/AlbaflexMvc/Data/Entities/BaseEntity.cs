namespace AlbaflexMvc.Data.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.Now.Date;
        public DateTime UpdatedAt { get; protected set; } = DateTime.Now.Date;

        public void UpdateAudit()
        {
            UpdatedAt = DateTime.Now.Date;
        }
    }
}
