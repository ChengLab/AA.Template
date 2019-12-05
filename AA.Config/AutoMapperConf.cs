using AA.AutoMapper;
using AA.Domain.Model;
using AA.Dto;
using AA.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.InitConfig.Mapper
{
    public class WebMapperConfigurations : IMapperConfiguration
    {
        public int Order { get { return 0; } }

        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                cfg.CreateMap<QuartzJobdetail, QuartzJobdetailDto>();
                cfg.CreateMap<QuartzJobdetailDto, QuartzJobdetailVm>();
                cfg.CreateMap<QuartzJobdetailVm, SaveQuartzJobdetailInput>();
                cfg.CreateMap<QuartzJobdetailVm, UpdateQuartzJobdetailInput>();
            };
            return action;
        }
    }
}

