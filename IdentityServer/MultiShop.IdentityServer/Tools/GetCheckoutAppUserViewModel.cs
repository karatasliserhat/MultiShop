﻿namespace MultiShop.IdentityServer.Tools
{
    public class GetCheckoutAppUserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsExits { get; set; }
    }
}
