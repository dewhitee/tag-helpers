using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Buttons
{
    [HtmlTargetElement("collapse-btn", TagStructure = TagStructure.WithoutEndTag)]
    public class CollapseButtonTagHelper : TagHelper
    {
        public string Text { get; set; }
        public string CollapseId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string buttonClass = "btn btn-dark";
            output.Content.SetHtmlContent(
                $"<a class='{buttonClass}' data-toggle='collapse' href='#{CollapseId}' role='button' aria-expanded='false' aria-controls='{CollapseId}'>" +
                $"{Text}" +
                "</a>");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
