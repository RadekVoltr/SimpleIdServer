﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Newtonsoft.Json.Linq;

namespace SimpleIdServer.Common.ExternalEvents
{
    public class IntegrationEvent
    {
        public IntegrationEvent(string id, int version, string resourceType)
        {
            Id = id;
            Version = version;
            ResourceType = resourceType;
        }


        public IntegrationEvent(string id, int version, string resourceType, JObject representation) : this(id, version, resourceType)
        {
            Representation = representation;
        }

        public string Id { get; set; }
        public int Version { get; set; }
        public string ResourceType { get; set; }
        public JObject Representation { get; set; }
    }
}
