using AA.Dapper.Repositories;
using AA.FrameWork.Domain;
using AA.Domain.Model;
using AA.Dto;
using AA.Dto.QuartzJobdetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.Domain.Repository
{
   public interface IQuartzJobdetailRepository: IDapperRepository<QuartzJobdetail>
    {
        IPage<QuartzJobdetailDto> GetListReturnOrder(GetListQuartzJobDetailInput input);
    }
}
