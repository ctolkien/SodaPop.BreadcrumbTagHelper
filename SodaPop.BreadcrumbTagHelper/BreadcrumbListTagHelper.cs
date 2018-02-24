using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SodaPop.BreadcrumbTagHelper
{
    /*
     * <ol itemscope itemtype="http://schema.org/BreadcrumbList">
  <li itemprop="itemListElement" itemscope
      itemtype="http://schema.org/ListItem">
    <a itemprop="item" href="https://example.com/dresses">
    <span itemprop="name">Dresses</span></a>
    <meta itemprop="position" content="1" />
  </li>
  <li itemprop="itemListElement" itemscope
      itemtype="http://schema.org/ListItem">
    <a itemprop="item" href="https://example.com/dresses/real">
    <span itemprop="name">Real Dresses</span></a>
    <meta itemprop="position" content="2" />
  </li>
</ol>
     */

    public class BreadcrumbListTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ol";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("itemscope", null);
            output.Attributes.SetAttribute("itemtype", "http://schema.org/BreadcrumbList");

            var content = (await output.GetChildContentAsync()).GetContent();


            var r = new Regex(BreadcrumbAnchorTagHelper.ReplacementPositionToken);

            var i = 1;
            //This goes through the string and replaces every match with an incrementing integer
            var result = r.Replace(content, match => { return (i++).ToString(); });


            output.Content.SetHtmlContent(result);
        }
    }
}
