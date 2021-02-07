using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("muted", TagStructure = TagStructure.WithoutEndTag)]
    public class MutedTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: "text-muted",
                bgClass: "bg-light",
                noteClass: "note-light",
                calloutClass: "bs-callout-light",
                additionalClasses: new string[] { "small" });
    }
}