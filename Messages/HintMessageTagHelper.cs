using Dewhitee.TagHelpers.Messages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("hint-msg", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HintMessageTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Hint.TextClass,
                bgClass: MessagesConfig.Hint.BackgroundClass,
                noteClass: MessagesConfig.Hint.NoteClass,
                calloutClass: MessagesConfig.Hint.CalloutClass,
                additionalClasses: MessagesConfig.Hint.AdditionalClasses);
    }
}
