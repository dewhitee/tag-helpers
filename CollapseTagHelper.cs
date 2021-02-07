using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers
{
    [HtmlTargetElement("collapse", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CollapseTagHelper : TagHelper
    {
        public string CollapseId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            output.Content.SetHtmlContent(
                $"<div class='collapse' id='{CollapseId}'>" +
                "<div class=''>" +
                content +
                "</div>" +
                "</div>");
        }
    }
}
