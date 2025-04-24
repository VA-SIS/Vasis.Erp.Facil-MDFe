﻿namespace Vasis.Erp.Facil.Api.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpireHours { get; set; } = 0;
    }
}
