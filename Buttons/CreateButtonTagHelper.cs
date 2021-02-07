using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Buttons
{
    [HtmlTargetElement("create-btn", TagStructure = TagStructure.WithoutEndTag)]
    public class CreateButtonTagHelper : InputButtonTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output, "Create", "btn btn-primary");
    }
}
