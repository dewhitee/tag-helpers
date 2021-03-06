﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    [HtmlTargetElement("success", TagStructure = TagStructure.WithoutEndTag)]
    public class SuccessTagHelper : MessageTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
            => OnProcess(context, output,
                textClass: MessagesConfig.Success.TextClass,
                bgClass: MessagesConfig.Success.BackgroundClass,
                noteClass: MessagesConfig.Success.NoteClass,
                calloutClass: MessagesConfig.Success.CalloutClass);
    }
}
