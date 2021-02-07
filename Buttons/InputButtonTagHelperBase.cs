using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Buttons
{
    public abstract class InputButtonTagHelperBase : TagHelper
    {
        protected void OnProcess(TagHelperContext context, TagHelperOutput output, string btnValue,
            string btnClass, string btnType = "submit")
        {
            output.Content.SetHtmlContent($"<input type='{btnType}' value='{btnValue}' class='{btnClass}' />");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
