using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace SodaPop.BreadcrumbTagHelper
{
    public class BreadcrumbAnchorTagHelper : AnchorTagHelper
    {
        public static string ReplacementPositionToken = "breadcrumb_position_placeholder";

        public BreadcrumbAnchorTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            var span = new TagBuilder("span");
            span.Attributes.Add("property", "name");
            span.InnerHtml.AppendHtml(content.GetContent());

            var meta = new TagBuilder("meta");
            meta.Attributes.Add("content", ReplacementPositionToken);
            meta.Attributes.Add("property", "position");
            meta.TagRenderMode = TagRenderMode.StartTag;

            output.TagName = "a";
            output.Attributes.SetAttribute("property", "item");
            output.Attributes.SetAttribute("typeof", "WebPage");



            if (!string.IsNullOrEmpty(Page))
            {
                //this is a razor page!
                var currentPage = ViewContext.RouteData.Values["Page"]?.ToString();
                if (currentPage != null && Page.Equals(currentPage, StringComparison.OrdinalIgnoreCase))
                {
                    var classBuilder = new TagBuilder("a");
                    classBuilder.Attributes.Add("class", "active");
                    output.MergeAttributes(classBuilder);
                }
            }
            else if (!string.IsNullOrEmpty(Action))
            {
                //mvc action
                var currentController = ViewContext.RouteData.Values["Controller"]?.ToString();
                var currentAction = ViewContext.RouteData.Values["Action"]?.ToString();
                if (Controller.Equals(currentController, StringComparison.OrdinalIgnoreCase) && Action.Equals(currentAction, StringComparison.OrdinalIgnoreCase))
                {
                    var classBuilder = new TagBuilder("a");
                    classBuilder.Attributes.Add("class", "active");
                    output.MergeAttributes(classBuilder);
                }
            }


            base.Process(context, output);

            output.Content.SetHtmlContent(span);
            output.Content.AppendHtml(meta);


        }
    }
}
