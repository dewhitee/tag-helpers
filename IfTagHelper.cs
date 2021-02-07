using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers
{
    [HtmlTargetElement(Attributes = "if", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class IfTagHelper : TagHelper
    {
        public bool If { get; set; }
        public override int Order => 50;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!If)
            {
                output.SuppressOutput();
            }
        }
    }
}
