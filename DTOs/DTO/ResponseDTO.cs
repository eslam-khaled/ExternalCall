using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    /// <summary>
    /// <see cref="Response"/> is a general dto
    /// </summary>
    public class ResponseDTO
    {
        /// <summary>
        /// Gets or sets the success message
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// Gets or sets the actual result
        /// </summary>
        public JObject result { get; set; }

        /// <summary>
        /// Gets or sets the English response message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Gets or sets the Arabic response message
        /// </summary>
        public string messageAR { get; set; }

        /// <summary>
        /// Gets or sets the error that the system may cause
        /// </summary>
        public string SystemError { get; set; }
        public int RequestId { get; set; }
    }
}
