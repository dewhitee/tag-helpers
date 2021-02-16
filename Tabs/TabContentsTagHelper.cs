using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dewhitee.TagHelpers.Tabs
{
    [HtmlTargetElement("tab-contents", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TabContentsTagHelper : TagHelper
    {
        public string TabsId { get; set; }
        //public TabsMode Mode { get; set; }
        
        public override int Order => 10;
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            var mode = context.Items[TabsTagHelper.ModeName] as TabsMode? ?? TabsMode.Horizontal;

            switch (mode)
            {
                case TabsMode.Vertical:
                    output.AddClass("col-9", HtmlEncoder.Default);
                    output.Content.SetHtmlContent(
                        $"<div class='tab-content' id='tabs-{TabsId}-contents'>" + content + "</div>");
                    break;
                case TabsMode.Horizontal:
                    output.AddClass("tab-content", HtmlEncoder.Default);
                    output.Attributes.SetAttribute("id", $"tabs-{TabsId}-contents");
                    output.Content.SetHtmlContent(content);
                    break;
                default:
                    output.AddClass("tab-content", HtmlEncoder.Default);
                    output.Attributes.SetAttribute("id", $"tabs-{TabsId}-contents");
                    output.Content.SetHtmlContent(content);
                    break;
            }
        }
    }
}