﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TrainCore.Authorization;

namespace TrainCore
{
    [DependsOn(
        typeof(TrainCoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TrainCoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TrainCoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TrainCoreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
