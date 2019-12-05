using System;
using System.Collections.Generic;
using System.Text;
using AA.Dapper.Configuration;
using AA.Dapper.FluentMap.Configuration;
using AA.DataAccess.EntityMap;
namespace AA.InitConfig
{
   public static class FluentDBMapConf
    {
        public static void Map()
        {
            Action<FluentMapConfiguration> mps = x =>
            {
            
                x.AddMap(new QuartzJobdetailMap());
             
            };
            var fluentMapconfig = new List<Action<FluentMapConfiguration>>();
            fluentMapconfig.Add(mps);
            MapConfiguration.Init(fluentMapconfig);
        }
    }
}


