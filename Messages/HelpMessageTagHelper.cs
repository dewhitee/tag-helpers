using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("help-msg", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HelpMessageTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Help.TextClass,
                bgClass: MessagesConfig.Help.BackgroundClass,
                noteClass: MessagesConfig.Help.NoteClass,
                calloutClass: MessagesConfig.Help.CalloutClass);
    }
}
