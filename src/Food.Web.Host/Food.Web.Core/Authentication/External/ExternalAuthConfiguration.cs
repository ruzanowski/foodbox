using System;
using System.Collections.Generic;
using Abp.Dependency;
using Microsoft.Extensions.Configuration;

namespace Food.Core.Authentication.External
{
    public class ExternalAuthConfiguration : IExternalAuthConfiguration, ISingletonDependency
    {
        public List<ExternalLoginProviderInfo> Providers { get; }

        public ExternalAuthConfiguration(IConfiguration configuration)
        {
            Providers = new List<ExternalLoginProviderInfo>()
            {
                new ExternalLoginProviderInfo(
                    FacebookAuthProvider.Name,
                    configuration["Authentication:Facebook:AppId"],
                    configuration["Authentication:Facebook:AppSecret"],
                    typeof(FacebookAuthProvider)
                )
            };
        }
    }
}
