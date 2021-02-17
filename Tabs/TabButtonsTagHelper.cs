using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dewhitee.TagHelpers.Tabs
{
    public enum TabsMode
    {
        Horizontal,
        Vertical
    }
    
    [HtmlTargetElement("tab-buttons", TagStructure = TagStructure.WithoutEndTag)]
    public class TabButtonsTagHelper : TagHelper
    {
        public string Titles { get; set; }
        public override int Order => 10;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var builder = new StringBuilder();
            var mode = context.Items[nameof(TabsTagHelper.Mode)] as TabsMode? ?? TabsMode.Horizontal;
            var tabsId = context.Items[nameof(TabsTagHelper.TabsId)] as string;
            
            string closingTag = "</div>";

            Func<string, bool, string> tabFunc;
            switch (mode)
            {
                case TabsMode.Horizontal:
                    tabFunc = SingleHorizontalTab;
                    output.TagName = "ul";
                    var ulClasses = "nav nav-tabs nav-justified mb-3".Split(' ');
                    foreach (var uc in ulClasses)
                        output.AddClass(uc, HtmlEncoder.Default);
                    output.Attributes.SetAttribute("role", "tablist");
                    closingTag = "</ul>";
                    break;
                case TabsMode.Vertical:
                    output.AddClass("col-3", HtmlEncoder.Default);
                    builder.Append($"<div class='nav flex-column nav-tabs text-center' id='tabs-{tabsId}' role='tablist' {ModeStr(mode)}>");
                    tabFunc = SingleVerticalTab;
                    break;
                default:
                    tabFunc = SingleHorizontalTab;
                    break;
            }

            // Remove spaces before and after ',' character and split into string array
            var titles = Regex.Replace(Titles, @$"\s*\{','}\s*", $"{','}").Split(',');

            switch (titles.Length)
            {
                case > 1:
                {
                    builder.Append(tabFunc(titles[0], true));
                    for (int i = 1; i < titles.Length; i++)
                    {
                        builder.Append(tabFunc(titles[i], false));
                    }

                    break;
                }
                case > 0:
                    builder.Append(tabFunc(titles[0], true));
                    break;
            }

            builder.Append(closingTag);
            output.Content.SetHtmlContent(builder.ToString());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private static string SingleVerticalTab(string content, bool active)
        {
            var (navLinkClass, ariaSelected) = GetTabClasses(active);
            return $"<a class='{navLinkClass}' id='tabs-{content}-tab' data-mdb-toggle='tab' href='#tabs-{content}'" + 
                   $"role='tab' aria-controls='tabs-{content}' aria-selected='{ariaSelected}'>{content}</a>";
        }

        private static string SingleHorizontalTab(string content, bool active)
        {
            var (navLinkClass, ariaSelected) = GetTabClasses(active);
            return "<li class='nav-item' role='presentation'>" +
                   $"<a class='{navLinkClass}' id='tabs-{content}-tab' " +
                   $"data-mdb-toggle='tab' href='#tabs-{content}'" + 
                   $"role='tab' aria-controls='tabs-{content}' aria-selected='{ariaSelected}'>{content}" +
                   "</a>" +
                   "</li>";
        }

        private static (string, string) GetTabClasses(bool active)
            => active ? ("nav-link active", "true") : ("nav-link", "false");
        
        private static string ModeStr(TabsMode mode) => mode switch
        {
            TabsMode.Horizontal => "",
            TabsMode.Vertical => "aria-orientation='vertical'",
            _ => ""
        };
    }
}