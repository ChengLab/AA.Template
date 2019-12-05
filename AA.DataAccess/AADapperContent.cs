using AA.Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace AA.DataAccess
{
  public  class AADapperContent : DapperContext
    {
        public AADapperContent() : base(new NameValueCollection()
        {
            ["aa.dataSource.AaBase.connectionString"] = "Data Source =.; Initial Catalog = QuartzAA-Job;User ID = sa; Password = lee2018;",
            ["aa.dataSource.AaBase.provider"] = "SqlServer"
        })
        {
        }
    }
}
