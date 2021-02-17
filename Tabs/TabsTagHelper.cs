using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dewhitee.TagHelpers.Tabs
{
    [HtmlTargetElement("tabs", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TabsTagHelper : TagHelper
    {
        /// <summary>
        /// Position mode of tabs. Can be <see cref="TabsMode.Horizontal"/> or <see cref="TabsMode.Vertical"/>.
        /// <see cref="TabsMode.Horizontal"/> will be used if no mode is specified.
        /// </summary>
        public TabsMode Mode { get; set; }

        /// <summary>
        /// Unique id of tabs section.
        /// </summary>
        public string TabsId { get; set; }

        public override int Order => 5;

        public override void Init(TagHelperContext context)
        {
            context.Items.Add(nameof(Mode), Mode);
            context.Items.Add(nameof(TabsId), TabsId);
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