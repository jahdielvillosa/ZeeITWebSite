using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelPackage.Models
{
    public partial class WebInquiryForm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int areaId { get; set; }
        public string LeadGuest { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int NoOfAdult { get; set; }
        public int NoOfChild { get; set; }
        public DateTime JobStart { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        public List<WebInquiryItems> items { get; set; }
    }

    public class WebInquiryItems
    {
        public int ProductId { get; set; }
        public DateTime dtStart { get; set; }
        public string Message { get; set; }
    }

}