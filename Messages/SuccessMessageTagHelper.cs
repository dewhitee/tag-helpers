using Dewhitee.TagHelpers.Messages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("success-msg", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SuccessMessageTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Success.TextClass,
                bgClass: MessagesConfig.Success.BackgroundClass,
                noteClass: MessagesConfig.Success.NoteClass,
                calloutClass: MessagesConfig.Success.CalloutClass);
    }
}
