using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace ApplicationChart.Models
{
    public class apiviettinbank
    {
       
        public class Request
        {
            public string requestId { get; set; }
            public string providerId { get; set; }
            public string merchantId { get; set; }
            public string trans_date { get; set; }
            public string language { get; set; }
            public string channel { get; set; }
            public string version { get; set; }
            public string clientIP { get; set; }
            public string signature { get; set; }

        }
        public class Status
        {
            public string code { get; set; }
            public string message { get; set; }
        }

        public class ForeignExchangeRateInfo
        {
            public string Currency { get; set; }
            public decimal Mid_Rate { get; set; }
            public decimal? Cash_Rate_Big { get; set; }
            public decimal Transfer_Rate { get; set; }
            public decimal Sell_Rate { get; set; }
        }

        public class Root
        {
            public string requestId { get; set; }
            public string providerId { get; set; }
            public string merchantId { get; set; }
            public Status status { get; set; }
            public List<ForeignExchangeRateInfo> ForeignExchangeRateInfo { get; set; }
        }


        public class Response
        {
            public string requestId { get; set; }
            public string providerId { get; set; }
            public string merchantId { get; set; }
            public Status status { get; set; }
            public string signature { get; set; }
            public List<ForeignExchangeRateInfo> ForeignExchangeRateInfo { get; set; }

        }
    }

}