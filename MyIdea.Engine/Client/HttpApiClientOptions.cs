using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Client
{
    public class HttpApiClientOptions
    {
        /// <summary>
        /// Базовый адрес сервиса
        /// </summary>
        public virtual string BaseUrl { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        public virtual string Host { get; set; }

        /// <summary>
        /// Http timeout
        /// </summary>
        public virtual TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(3);

        /// <summary>
        /// Token
        /// </summary>
        public virtual string Token { get; set; }
    }
}
