﻿namespace ASP.NET_7_SendEmail.Models
{
    public class EmailDTO
    {
        public string To { get; set; } = string.Empty;

        public string Issue { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;
    }
}
