using System;
using System.Collections.Generic;
using System.Text;
namespace AA.Domain.Model
{
   public class QuartzJobdetail
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 任务组
        /// </summary>
        public string JobGroup
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 运行状态
        /// </summary>
        public int RunStatus
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// cron表达式
        /// </summary>
        public string Cron
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime GmtCreateTime
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// api地址
        /// </summary>
        public string ApiUrl
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get;
            set;
        }
             
          
     }
}


