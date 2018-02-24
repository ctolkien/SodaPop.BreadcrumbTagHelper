using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SodaPop.BreadcrumbTagHelper
{
    public class BreadcrumbTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "li";

            output.Attributes.SetAttribute("property", "itemListElement");
            output.Attributes.SetAttribute("typeof", "ListItem");
        }
    }
}
