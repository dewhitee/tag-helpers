using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("error", TagStructure = TagStructure.WithoutEndTag)]
    public class ErrorTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Error.TextClass,
                bgClass: MessagesConfig.Error.BackgroundClass,
                noteClass: MessagesConfig.Error.NoteClass,
                calloutClass: MessagesConfig.Error.CalloutClass);
    }
}
