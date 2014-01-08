using System;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

namespace Resharper.ProtoBuf.Rules
{
    [StaticSeverityHighlighting(Severity.ERROR, CSharpLanguage.Name)]
    public class TagValueWarning : IHighlighting
    {
        private readonly TagError error;

        public TagValueWarning(TagError error)
        {
            this.error = error;
        }

        public bool IsValid()
        {
            return true;
        }

        public string ToolTip
        {
            get
            {
                switch (error)
                {
                    case TagError.Zero:
                        return "Protocol Buffers tags cannot be 0, choose a tag that is greater than 0.";
                    case TagError.Negative:
                        return "Protocol Buffers tags cannot be negative, choose a tag number that is greater than 0.";
                    case TagError.Reserved:
                        return "Tag numbers 19000 through 19999 are reserved for internal Protocol Buffers implementation and cannot be used.";
                    case TagError.TooBig:
                        return "Protocol Buffers tags cannot be grater than 2^29 - 1 or 536,870,911";
                }
                
                return "Unknown error " + error;
            }
        }

        public string ErrorStripeToolTip
        {
            get { return ToolTip; }
        }

        public int NavigationOffsetPatch { get { return 0;  } }
    }
}