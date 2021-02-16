using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dewhitee.TagHelpers.Tabs
{
    [HtmlTargetElement("tabs", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TabsTagHelper : TagHelper
    {
        public const string ModeName = "TabsMode";
        public TabsMode Mode { get; set; }
        public override int Order => 5;

        public override void Init(TagHelperContext context)
        {
            context.Items.Add(ModeName, Mode);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();

            switch (Mode)
            {
                case TabsMode.Horizontal:
                    output.Content.SetHtmlContent(content);
                    break;
                case TabsMode.Vertical:
                    output.Content.SetHtmlContent(
                        "<div class='row'>" +
                        content +
                        "</div>");
                    break;
                default:
                    output.Content.SetHtmlContent(content);
                    break;
            }
        }
    }
}