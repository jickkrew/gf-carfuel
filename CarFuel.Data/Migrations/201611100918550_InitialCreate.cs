namespace CarFuel.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        Make = c.String(nullable: false, maxLength: 20),
                        Modal = c.String(nullable: false, maxLength: 30,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "AuthorName",
                                    new AnnotationValues(oldValue: null, newValue: "Veerakit T")
                                },
                            }),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FillUps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IsFull = c.Boolean(nullable: false),
                        Liters = c.Double(nullable: false),
                        Odometer = c.Int(nullable: false),
                        NextFillUp_id = c.Int(),
                        Car_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FillUps", t => t.NextFillUp_id)
                .ForeignKey("dbo.Cars", t => t.Car_id)
                .Index(t => t.NextFillUp_id)
                .Index(t => t.Car_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillUps", "Car_id", "dbo.Cars");
            DropForeignKey("dbo.FillUps", "NextFillUp_id", "dbo.FillUps");
            DropIndex("dbo.FillUps", new[] { "Car_id" });
            DropIndex("dbo.FillUps", new[] { "NextFillUp_id" });
            DropTable("dbo.FillUps");
            DropTable("dbo.Cars",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Modal",
                        new Dictionary<string, object>
                        {
                            { "AuthorName", "Veerakit T" },
                        }
                    },
                });
        }
    }
}
