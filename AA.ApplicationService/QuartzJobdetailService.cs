using AA.Dapper.Repositories;
using AA.FrameWork.Application.Services.Dto;
using AA.FrameWork.Domain;
using AA.DataAccess;
using AA.DataAccess.Repository;
using AA.Domain.Model;
using AA.Domain.Repository;
using AA.Dto;
using AA.Dto.QuartzJobdetail;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AA.ApplicationService
{
    public class QuartzJobdetailService : IQuartzJobdetailService
    {
        #region filed
        private readonly IQuartzJobdetailRepository _quartzJobdetailRepository;
        #endregion 

        #region actor
        public QuartzJobdetailService()
        {
            var dapperContent = new AADapperContent();
            _quartzJobdetailRepository = new QuartzJobdetailRepository();
        }
        #endregion

        public void Save(SaveQuartzJobdetailInput input)
        {
            var obj = _quartzJobdetailRepository.Insert(new QuartzJobdetail
            {
                JobGroup = input.JobGroup,
                JobName = input.JobName,
                RunStatus = input.RunStatus,
                Cron = input.Cron,
                StartTime = input.StartTime,
                EndTime = input.EndTime,
                Description = input.Description,
                GmtCreateTime = DateTime.Now,
                ApiUrl = input.ApiUrl,
                Status = input.Status,
            });
        }

        public void Update(UpdateQuartzJobdetailInput input)
        {
            var model = _quartzJobdetailRepository.Get(input.Id);
            model.JobGroup = input.JobGroup;
            model.JobName = input.JobName;
            model.Cron = input.Cron;
            model.StartTime = input.StartTime;
            model.EndTime = input.EndTime;
            model.Description = input.Description;
            model.ApiUrl = input.ApiUrl;
            _quartzJobdetailRepository.Update(model);
        }
        public void Remove(RemoveQuartzJobdetailInput input)
        {
            var model = _quartzJobdetailRepository.Get(input.Id);
            _quartzJobdetailRepository.Delete(model);
        }
        public QuartzJobdetailDto GetQuartzJobdetail(GetQuartzJobdetailInput input)
        {
            var model = _quartzJobdetailRepository.FirstOrDefault(p => p.Description.Contains(input.Description));
            return new QuartzJobdetailDto()
            {

                JobGroup = model.JobGroup,
                JobName = model.JobName,
                RunStatus = model.RunStatus,
                Cron = model.Cron,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Description = model.Description,
                ApiUrl = model.ApiUrl,

            };
        }
        public PagedResultDto<QuartzJobdetailDto> GetList(GetListQuartzJobDetailInput input)
        {
            var result = _quartzJobdetailRepository.GetListReturnOrder(input);
            return new PagedResultDto<QuartzJobdetailDto>
            {
                TotalCount = result.Count,
                Items = result.Data.ToList()
            };
        }

    }
}
