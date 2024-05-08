// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermisson","CatalogReadPermisson"}},
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermisson"}},
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermisson"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermisson"} },
           new ApiResource("ResourceBasket"){Scopes={"BasketFullPermisson"} },
           new ApiResource("ResourceComment"){Scopes={"CommentFullPermisson"} },
           new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermisson"} },
           new ApiResource("ResourceImage"){Scopes={"ImageFullPermisson"} },
           new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermisson"} },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
       };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermisson","Full Authority for Catalog Operations"),
            new ApiScope("CatalogReadPermisson", "Read Authority for Catalog Operations"),
            new ApiScope("DiscountFullPermisson","Full Authority for Discount Operations"),
            new ApiScope("OrderFullPermisson","Full Authority for Order Operations"),
            new ApiScope("CargoFullPermisson","Full Authority for Cargo Operations"),
            new ApiScope("BasketFullPermisson","Full Authority for Basket Operations"),
            new ApiScope("CommentFullPermisson","Full Authority for Comment Operations"),
            new ApiScope("PaymentFullPermisson","Full Authority for Payment Operations"),
            new ApiScope("ImageFullPermisson","Full Authority for Image Operations"),
            new ApiScope("OcelotFullPermisson","Full Authority for Ocelot Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[] {

            new Client
            {

                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermisson","CommentFullPermisson","CatalogFullPermisson", "ImageFullPermisson", "OrderFullPermisson", "OcelotFullPermisson" },
            },
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermisson", "CatalogReadPermisson","DiscountFullPermisson", "CommentFullPermisson", "BasketFullPermisson", "ImageFullPermisson","OrderFullPermisson", "OcelotFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermisson", "CatalogReadPermisson", "DiscountFullPermisson", "OrderFullPermisson","CargoFullPermisson","BasketFullPermisson","CommentFullPermisson", "OcelotFullPermisson","PaymentFullPermisson","ImageFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600


            }

        };
    }
}