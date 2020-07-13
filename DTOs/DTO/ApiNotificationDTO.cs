using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class ApiNotificationDTO
    {
        /// <summary>
        /// Gets or sets the subject 
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// Gets or sets the message 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Gets or sets the accountNumber 
        /// </summary>
        public string accountNumber { get; set; }

        /// <summary>
        /// url inserted by front user
        /// </summary>
        public string url { get; set; }
    }
}
