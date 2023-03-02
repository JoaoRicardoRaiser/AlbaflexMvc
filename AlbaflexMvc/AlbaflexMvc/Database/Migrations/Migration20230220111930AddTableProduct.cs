using FluentMigrator;

namespace AlbaflexMvc.Database.Migrations
{
    [Migration(20230220111930, "Added table tissue")]
    public class Migration20230220111930AddTableProduct : Migration
    {
        public override void Up()
        {
            Create.Table("product")
                .WithColumn("code").AsInt32().Unique().NotNullable().PrimaryKey()
                .WithColumn("description").AsString().NotNullable()
                .WithColumn("value").AsDouble().NotNullable()
                .WithColumn("type").AsString().NotNullable()
                .WithColumn("created_at").AsDateTime().NotNullable()
                .WithColumn("updated_at").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("tissue");
        }
    }
}
