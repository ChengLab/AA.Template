using AA.Dapper;
using AA.Dapper.Repositories;
using AA.FrameWork.Domain;
using AA.Domain.Model;
using AA.Domain.Repository;
using AA.Dto;
using AA.Dto.QuartzJobdetail;
using System;
using System.Collections.Generic;
using System.Text;


namespace AA.DataAccess.Repository
{
    public class QuartzJobdetailRepository:DapperRepository<QuartzJobdetail>, IQuartzJobdetailRepository
    {
        public IPage<QuartzJobdetailDto> GetListReturnOrder(GetListQuartzJobDetailInput input)
        {
            object sqlParam = null;
            var sql = new StringBuilder();
            sql.Append("select *  from QuartzJobdetail ");
            sql.Append(" where 1=1");
            var result = DapperContext.Current.DataBase.GetPage<QuartzJobdetailDto>(new PageRequest
            {
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                SqlText = sql.ToString(),
                SqlParam = sqlParam,
                OrderFiled = " Id desc ",
            });
            return result;
        }
    }
}

