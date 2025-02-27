﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.Saml.Xsd;

namespace SimpleIdServer.Saml.Idp.Apis.Metadata
{
    public interface IMetadataHandler
    {
        EntityDescriptorType Get();
    }
}
