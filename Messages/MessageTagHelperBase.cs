using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dewhitee.TagHelpers.Messages
{
    /// <summary>
    /// Message mode enumeration, defines the way message tag renders.
    /// </summary>
    public enum MessageMode
    {
        Text,
        Card,
        Outlined,
        Note,
        Callout,
        Modal
    }

    public abstract class MessageTagHelperBase : TagHelper
    {
        /// <summary>
        /// Message HTML content string.
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Condition to render this message.
        /// </summary>
        public bool When { get; set; } = true;

        /// <summary>
        /// Mode that defines the rules how to render the message.
        /// </summary>
        public MessageMode As { get; set; }

        /// <summary>
        /// Specifies which role (any of the roles specified, if many) must user have to see this message.
        /// If multiple roles required, type them separated by comma.
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// User reference.
        /// </summary>
        public ClaimsPrincipal User { get; set; }

        /// <summary>
        /// Id of a button or anchor element that triggers this message if it is set as modal.
        /// </summary>
        public string ModalId { get; set; }

        /// <summary>
        /// Rendering order of this tag.
        /// </summary>
        public override int Order => 100;

        protected void OnProcess(TagHelperContext context, TagHelperOutput output, string textClass, string bgClass, string noteClass, string calloutClass,
            string[] additionalClasses = null)
        {
            bool validRole = false;
            if (User is not null && !string.IsNullOrEmpty(Roles))
            {
                string[] roles = Roles.Contains(',') ? Roles.Split(',') : new string[] { Roles };
                foreach (string role in roles)
                {
                    if (User.IsInRole(role))
                    {
                        validRole = true;
                        break;
                    }
                }
            }

            bool validMsg = When && !string.IsNullOrEmpty(Msg);
            bool validUser = (User is not null && validRole) || User is null;

            if (validMsg && validUser)
            {
                switch (As)
                {
                    case MessageMode.Text:
                        OnDefault(output, textClass, additionalClasses);
                        break;
                    case MessageMode.Card:
                        OnCard(output, textClass, bgClass, additionalClasses, outlined: false);
                        break;
                    case MessageMode.Outlined:
                        OnOutlined(output, textClass, bgClass, additionalClasses);
                        break;
                    case MessageMode.Note:
                        OnNote(output, noteClass, additionalClasses);
                        break;
                    case MessageMode.Callout:
                        OnCallout(output, calloutClass, additionalClasses);
                        break;
                    case MessageMode.Modal:
                        OnModal(output, additionalClasses);
                        break;
                    default:
                        OnDefault(output, textClass, additionalClasses);
                        break;
                }
            }
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private void OnDefault(TagHelperOutput output, string textClass, string[] additionalClasses)
        {
            output.TagName = "p";
            output.AddClass(textClass, HtmlEncoder.Default);
            AddAdditionalClasses(output, additionalClasses);

            output.Content.SetHtmlContent(Msg);
        }

        private void OnCard(TagHelperOutput output, string textClass, string bgClass, string[] additionalClasses, bool outlined)
        {
            output.TagName = "div";

            output.AddClass("card", HtmlEncoder.Default);
            output.AddClass(bgClass, HtmlEncoder.Default);
            AddAdditionalClasses(output, additionalClasses);

            string defaultText = "text-white";

            output.Content.SetHtmlContent(
                "<div class=\"card-body p-2\">" +
                $"<p class=\"card-text {(outlined ? textClass : defaultText)} p-1 m-1\">{Msg}</p>" +
                "</div>");
        }

        private void OnOutlined(TagHelperOutput output, string textClass, string bgClass, string[] additionalClasses)
        {
            SetBackgroundOutlined("note-", ref bgClass);
            SetBackgroundOutlined("bg-", ref bgClass);
            OnCard(output, textClass, bgClass, additionalClasses, outlined: true);
        }

        private static void SetBackgroundOutlined(string inClass, ref string bgClass)
        {
            if (bgClass.StartsWith(inClass))
                bgClass = $"border-{bgClass.Remove(0, inClass.Length)}";
        }

        private void OnNote(TagHelperOutput output, string noteClass, string[] additionalClasses)
        {
            output.TagName = "p";

            output.AddClass("note", HtmlEncoder.Default);
            output.AddClass(noteClass, HtmlEncoder.Default);
            AddAdditionalClasses(output, additionalClasses);

            output.Content.SetHtmlContent(Msg);
        }

        private void OnCallout(TagHelperOutput output, string calloutClass, string[] additionalClasses)
        {
            output.TagName = "div";

            output.AddClass("bs-callout", HtmlEncoder.Default);
            output.AddClass(calloutClass, HtmlEncoder.Default);
            AddAdditionalClasses(output, additionalClasses);

            output.Content.SetHtmlContent($"<p>{Msg}</p>");
        }

        private void OnModal(TagHelperOutput output, string[] additionalClasses)
        {
            string modalClass = !string.IsNullOrEmpty(ModalId) ? "modal fade" : "modal";
            string id = ModalId;
            int tabIndex = -1;
            string role = "dialog";
            string labelledBy = ModalId + "-title";
            bool ariaHidden = true;

            string modalDialogClass = "modal-dialog modal-dialog-centered";
            string modalDialogRole = "document";

            string modalContentClass = "modal-content";

            string modalHeaderClass = "modal-header";

            string modalTitleClass = "modal-title";
            string modalTitleText = "Help";

            string modalBodyClass = "modal-body";

            string modalFooterClass = "modal-footer";

            output.Content.SetHtmlContent(
                $"<div class='{modalClass}' id='{id}' tabindex='{tabIndex}' role='{role}' aria-labelledby='{labelledBy}' aria-hidden='{ariaHidden}'>" +
                $"  <div class='{modalDialogClass}' role='{modalDialogRole}'>" +
                $"      <div class='{modalContentClass}'>" +
                $"          <div class='{modalHeaderClass}'>" +
                $"              <h5 class='{modalTitleClass}' id='{labelledBy}'><strong>{modalTitleText}</strong>" +
                "               </h5>" +
                $"              <button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                "                   <span aria-hidden='true'>&times;" +
                "                   </span>" +
                "               </button>" +
                "           </div>" +
                $"          <div class='{modalBodyClass}'>" +
                $"              <p>{Msg}" +
                "               </p>" +
                "           </div>" +
                $"          <div class='{modalFooterClass}'>" +
                "               <button type='button' class='btn btn-secondary' data-dismiss='modal'>Close" +
                "               </button>" +
                "           </div>" +
                "       </div>" +
                "   </div>" +
                "</div>");
        }

        private static void AddAdditionalClasses(TagHelperOutput output, string[] additionalClasses)
        {
            if (additionalClasses is not null)
            {
                foreach (var @class in additionalClasses)
                    output.AddClass(@class, HtmlEncoder.Default);
            }
        }
    }
}
