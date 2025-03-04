﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.OAuth.Domains;
using SimpleIdServer.Uma.Domains;
using System;
using System.Collections.Generic;

namespace SimpleIdServer.Uma.SqlServer.Startup
{
    public class UmaDefaultConfiguration
    {
        public static List<UMAResource> Resources = new List<UMAResource>
        {
            new UMAResource(Guid.NewGuid().ToString(), DateTime.UtcNow)
            {
                Translations = new List<UMAResourceTranslation>
                {
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "first resource", "en")
                        {
                            Type = "description"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "première ressource", "fr")
                        {
                            Type = "description"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "first resource", "en")
                        {
                            Type = "name"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "première ressource", "fr")
                        {
                            Type = "name"
                        }
                    }
                },
                Scopes = new List<string>
                {
                    "scope1",
                    "scope2"
                },
                Subject = "sub",
                Type = "type"
            },
            new UMAResource(Guid.NewGuid().ToString(), DateTime.UtcNow)
            {
                Translations = new List<UMAResourceTranslation>
                {
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "first resource", "en")
                        {
                            Type = "description"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "première ressource", "fr")
                        {
                            Type = "description"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "first resource", "en")
                        {
                            Type = "name"
                        }
                    },
                    new UMAResourceTranslation
                    {
                        Translation = new OAuthTranslation(Guid.NewGuid().ToString(), "première ressource", "fr")
                        {
                            Type = "name"
                        }
                    }
                },
                Scopes = new List<string>
                {
                    "scope1",
                    "scope2"
                },
                Subject = "guest",
                Type = "type"
            }
        };

        public static List<OAuthScope> DefaultScopes = new List<OAuthScope>
        {
            UMAConstants.StandardUMAScopes.UmaProtection
        };

        public static List<OAuthClient> DefaultClients = new List<OAuthClient>
        {
            new OAuthClient
            {
                ClientId = "api",
                ClientSecret = "apiSecret",
                TokenEndPointAuthMethod = "client_secret_post",
                UpdateDateTime = DateTime.UtcNow,
                CreateDateTime = DateTime.UtcNow,
                TokenExpirationTimeInSeconds = 60 * 30,
                RefreshTokenExpirationTimeInSeconds = 60 * 30,
                TokenSignedResponseAlg = "RS256",
                AllowedScopes = new List<OAuthScope>
                {
                    UMAConstants.StandardUMAScopes.UmaProtection
                },
                GrantTypes = new List<string>
                {
                    "client_credentials"
                },
                RedirectionUrls = new List<string>
                {
                    "https://localhost:5001/signin-oidc"
                },
                PreferredTokenProfile = "Bearer",
                ResponseTypes = new List<string>
                {
                    "token"
                }
            },
            new OAuthClient
            {
                ClientId = "portal",
                ClientSecret = "portalSecret",
                TokenEndPointAuthMethod = "client_secret_post",
                UpdateDateTime = DateTime.UtcNow,
                CreateDateTime = DateTime.UtcNow,
                TokenExpirationTimeInSeconds = 60 * 30,
                RefreshTokenExpirationTimeInSeconds = 60 * 30,
                TokenSignedResponseAlg = "RS256",
                AllowedScopes = new List<OAuthScope>
                {
                    UMAConstants.StandardUMAScopes.UmaProtection
                },
                GrantTypes = new List<string>
                {
                    "urn:ietf:params:oauth:grant-type:uma-ticket"
                },
                PreferredTokenProfile = "Bearer",
                ResponseTypes = new List<string>
                {
                    "token"
                }
            }
        };
    }
}