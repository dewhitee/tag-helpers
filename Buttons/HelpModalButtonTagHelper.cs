using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Buttons
{
    [HtmlTargetElement("help-modal-btn", TagStructure = TagStructure.WithoutEndTag)]
    public class HelpModalButtonTagHelper : TagHelper
    {
        public string ModalId { get; set; }
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string style = "cursor:pointer;";
            string iconClass = "far fa-question-circle";
            string dataToggle = "modal";
            string dataTarget = "#" + ModalId;

            output.Content.SetHtmlContent(
                $"<a data-toggle='{dataToggle}' data-target='{dataTarget}'><i class='{iconClass}' style='{style}'></i></a>");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
