using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "ThisNetWorks OrchardCore CKEditor",
    Author = "ThisNetWorks",
    Website = "https://github.com/thisnetworks",
    Version = "1.0.0",
    Description = "ThisNetWorks CKEditor editors and media plugins",
    Dependencies = new[] 
    { 
        "OrchardCore.ContentFields", 
        "OrchardCore.Html"
    },
    Category = "Content Management"
)]
