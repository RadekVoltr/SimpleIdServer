﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Newtonsoft.Json.Linq;
using SimpleIdServer.Common.ExternalEvents;

namespace SimpleIdServer.Scim.ExternalEvents
{
    public class RepresentationUpdatedEvent : IntegrationEvent
    {
        public RepresentationUpdatedEvent(string id, int version, string resourceType, JObject representation, string token) : base(id, version, resourceType, representation) 
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
