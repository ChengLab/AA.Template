using AA.FrameWork.Application.Services.Dto;
using AA.Dto;
using AA.Dto.QuartzJobdetail;
using System;
using System.Collections.Generic;
using System.Text;
namespace AA.ApplicationService
{
    public interface IQuartzJobdetailService
    {
        void Save(SaveQuartzJobdetailInput input);
        void Update(UpdateQuartzJobdetailInput input);
        void Remove(RemoveQuartzJobdetailInput input);
        QuartzJobdetailDto GetQuartzJobdetail(GetQuartzJobdetailInput input);
        PagedResultDto<QuartzJobdetailDto> GetList(GetListQuartzJobDetailInput input);
    }
}


