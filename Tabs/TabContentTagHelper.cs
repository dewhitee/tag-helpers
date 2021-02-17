using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dewhitee.TagHelpers.Tabs
{
    [HtmlTargetElement("tab-content", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TabContentTagHelper : TagHelper
    {
        /// <summary>
        /// Name of a tab button that opens/closes this tab.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// If true - will be shown by default.
        /// </summary>
        public bool Active { get; set; }
        
        public override int Order => 15;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string paneClass = Active ? "tab-pane fade show active" : "tab-pane fade";
            foreach (var @class in paneClass.Split(' '))
                output.AddClass(@class, HtmlEncoder.Default);
            
            output.Attributes.SetAttribute("id", $"tabs-{Title}");
            output.Attributes.SetAttribute("role", "tabpanel");
            output.Attributes.SetAttribute("aria-labelledby", $"tabs-{Title}-tab");
            
            output.Content.SetHtmlContent(content);
        }
    }
}