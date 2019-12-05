using AA.Dapper.FluentMap.Dommel.Mapping;
using AA.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.DataAccess.EntityMap
{
   public class QuartzJobdetailMap:DommelEntityMap<QuartzJobdetail>
    {
        public QuartzJobdetailMap()
        {
            ToTable("QuartzJobdetail");
            
            Map(x=>x.Id).IsKey().IsIdentity();
        }
    }
}

