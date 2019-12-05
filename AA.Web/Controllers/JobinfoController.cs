using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AA.AspNetCore.Results;
using AA.FrameWork.Extensions;
using AA.Web.Models;
using AA.ApplicationService;
using AA.Dto;
using AA.Dto.QuartzJobdetail;
using AA.ViemModel;
using AA.ViemModel.QuartzJobdetail;
using AA.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AA.Web.Controllers
{
    public class JobinfoController : Controller
    {
        #region Fields
        private readonly IQuartzJobdetailService _quartzJobdetailService;
        #endregion

        public JobinfoController()
        {
            _quartzJobdetailService = new QuartzJobdetailService();
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// job列表
        /// </summary>
        /// <param name="limit">每页显示条数</param>
        /// <param name="start"></param>
        /// <param name="page">页码</param>
        /// <param name="draw"></param>
        /// <returns></returns>
        public IActionResult GetListQuartzJobdetail(int limit, int start, int page, int draw)
        {
            var result = _quartzJobdetailService.GetList(new GetListQuartzJobDetailInput()
            {
                PageIndex = page,
                PageSize = limit,
            });

            var vm = new PageResponse<QuartzJobdetailViewModel>
            {
                draw = draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = result.Items.MapTo<List<QuartzJobdetailViewModel>>()
            };
            return Json(vm);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IActionResult Save(QuartzJobdetailVm vm)
        {
            _quartzJobdetailService.Save(vm.MapTo<SaveQuartzJobdetailInput>());
            return Json(Result.Success("操作成功"));
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IActionResult Update(QuartzJobdetailVm vm)
        {
            _quartzJobdetailService.Update(vm.MapTo<UpdateQuartzJobdetailInput>());
            return Json(Result.Success("修改成功"));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _quartzJobdetailService.Remove(new RemoveQuartzJobdetailInput { Id = id });
            return Json(Result.Success("删除成功"));
        }
        //TODO 。。。。。
        //暂停
        //开始运行
    }
}