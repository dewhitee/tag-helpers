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
                textClass: MessagesConfig.Muted.TextClass,
                bgClass: MessagesConfig.Muted.BackgroundClass,
                noteClass: MessagesConfig.Muted.NoteClass,
                calloutClass: MessagesConfig.Muted.CalloutClass,
                additionalClasses: MessagesConfig.Muted.AdditionalClasses);
    }
}