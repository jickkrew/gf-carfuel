namespace CarFuel.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 30,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "AuthorName",
                        new AnnotationValues(oldValue: null, newValue: "Veerakit T")
                    },
                }));
            DropColumn("dbo.Cars", "Modal",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "AuthorName", "Veerakit T" },
                });
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Modal", c => c.String(nullable: false, maxLength: 30,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "AuthorName",
                        new AnnotationValues(oldValue: null, newValue: "Veerakit T")
                    },
                }));
            DropColumn("dbo.Cars", "Model",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "AuthorName", "Veerakit T" },
                });
        }
    }
}
