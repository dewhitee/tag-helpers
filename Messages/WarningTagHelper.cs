﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("warn", TagStructure = TagStructure.WithoutEndTag)]
    public class WarningTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Warning.TextClass,
                bgClass: MessagesConfig.Warning.BackgroundClass,
                noteClass: MessagesConfig.Warning.NoteClass,
                calloutClass: MessagesConfig.Warning.CalloutClass);
    }
}
