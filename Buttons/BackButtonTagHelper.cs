using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Buttons
{
    [HtmlTargetElement("back-btn", TagStructure = TagStructure.WithoutEndTag)]
    public class BackButtonTagHelper : TagHelper
    {
        public string Route { get; set; }
        public string For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string href = Route;
            string @class = "btn btn-light text-dark";

            output.Content.SetHtmlContent(
                $"<a id='back-btn' href='{href}' class='{@class}'>Back</a>");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
