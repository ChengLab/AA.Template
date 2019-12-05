using System;
using System.Collections.Generic;
using System.Text;
namespace AA.ViewModel
{
   public class QuartzJobdetailVm
    {
		/// <summary>
		/// Primary，	  
		/// </summary>
        public int Id { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public string JobGroup { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public string JobName { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public int RunStatus { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public string Cron { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public DateTime StartTime { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public DateTime EndTime { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public string Description { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public DateTime GmtCreateTime { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public string ApiUrl { get; set; }
		/// <summary>
		/// 	  
		/// </summary>
        public int Status { get; set; }
    }
}


