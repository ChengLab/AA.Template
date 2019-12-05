using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Web.Models
{
    public class LteTableViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<QuartzJobdetailViewModel> data { get; set; }
        public string error { get; set; }
    }

    public class QuartzJobdetailViewModel
    {
        #region	属性

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// JobGroup
        /// </summary>
        public string JobGroup
        {
            get;
            set;
        }

        /// <summary>
        /// JobName
        /// </summary>
        public string JobName
        {
            get;
            set;
        }

        /// <summary>
        /// RunStatus
        /// </summary>
        public string RunStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Cron
        /// </summary>
        public string Cron
        {
            get;
            set;
        }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// GmtCreateTime
        /// </summary>
        public DateTime GmtCreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// ApiUrl
        /// </summary>
        public string ApiUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        #endregion

    }
}
