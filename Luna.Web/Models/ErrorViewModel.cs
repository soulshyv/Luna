using System;

namespace Luna.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool CanDisplayFullError { get; set; }

        public Exception Error { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}