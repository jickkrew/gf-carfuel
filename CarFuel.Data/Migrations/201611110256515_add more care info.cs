namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmorecareinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "PlateNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Cars", "Color", c => c.String(maxLength: 30));
            Sql("Update dbo.Cars SET color='Black'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Color");
            DropColumn("dbo.Cars", "PlateNo");
        }
    }
}
