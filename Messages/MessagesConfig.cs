using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dewhitee.TagHelpers.Messages
{
    public static class MessagesConfig
    {
        public static class Success
        {
            public const string TextClass = "text-success";
            public const string BackgroundClass = "bg-success";
            public const string NoteClass = "note-success";
            public const string CalloutClass = "bs-callout-success";
        }

        public static class Error
        {
            public const string TextClass = "text-danger";
            public const string BackgroundClass = "bg-danger";
            public const string NoteClass = "note-danger";
            public const string CalloutClass = "bs-callout-danger";
        }

        public static class Warning
        {
            public const string TextClass = "text-warning";
            public const string BackgroundClass = "bg-warning";
            public const string NoteClass = "note-warning";
            public const string CalloutClass = "bs-callout-warning";
        }

        public static class Hint
        {
            public const string TextClass = "text-muted";
            public const string BackgroundClass = "bg-light";
            public const string NoteClass = "note-light";
            public const string CalloutClass = "bs-callout-light";
            public static readonly string[] AdditionalClasses = new string[] { "small", "hint" };
        }

        public static class Muted
        {
            public const string TextClass = "text-muted";
            public const string BackgroundClass = "bg-light";
            public const string NoteClass = "note-light";
            public const string CalloutClass = "bs-callout-light";
            public static readonly string[] AdditionalClasses = new string[] { "small" };
        }

        public static class Help
        {
            public const string TextClass = "text-muted";
            public const string BackgroundClass = "bg-light";
            public const string NoteClass = "note-light";
            public const string CalloutClass = "bs-callout-light";
        }
    }
}
