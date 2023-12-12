﻿using Microsoft.AspNetCore.Http;

namespace Asterisk.Shared.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();
    }
}
