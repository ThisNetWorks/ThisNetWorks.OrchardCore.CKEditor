using OrchardCore.DisplayManagement.Descriptors;

namespace ThisNetWorks.OrchardCore.CKEditor.Shapes
{
    public class HtmlMediaShapes : IShapeTableProvider
    {
        public void Discover(ShapeTableBuilder builder)
        {
            builder.Describe("HtmlBodyPart_Edit")
                .OnDisplaying(displaying =>
                {
                    var editor = displaying.Shape;

                    if (editor.Metadata.Type == "HtmlBodyPart_Edit__CKEditorClassic")
                    {
                        editor.Metadata.Wrappers.Add("Media_Wrapper__HtmlBodyPart");
                    }
                });

            builder.Describe("HtmlField_Edit")
                .OnDisplaying(displaying =>
                {
                    var editor = displaying.Shape;

                    if (editor.Metadata.Type == "HtmlField_Edit__CKEditorClassic")
                    {
                        editor.Metadata.Wrappers.Add("Media_Wrapper__HtmlField");
                    }
                });                
        }
    }
}
