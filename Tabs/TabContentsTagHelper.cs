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
        public override int Order => 10;
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            var mode = context.Items[nameof(TabsTagHelper.Mode)] as TabsMode? ?? TabsMode.Horizontal;
            var tabsId = context.Items[nameof(TabsTagHelper.TabsId)] as string;
            
            switch (mode)
            {
                case TabsMode.Vertical:
                    output.AddClass("col-9", HtmlEncoder.Default);
                    output.AddClass("pl-5", HtmlEncoder.Default);
                    output.Content.SetHtmlContent(
                        $"<div class='tab-content' id='tabs-{tabsId}-contents'>" + content + "</div>");
                    break;
                case TabsMode.Horizontal:
                    output.AddClass("tab-content", HtmlEncoder.Default);
                    output.Attributes.SetAttribute("id", $"tabs-{tabsId}-contents");
                    output.Content.SetHtmlContent(content);
                    break;
                default:
                    output.AddClass("tab-content", HtmlEncoder.Default);
                    output.Attributes.SetAttribute("id", $"tabs-{tabsId}-contents");
                    output.Content.SetHtmlContent(content);
                    break;
            }
        }
    }
}