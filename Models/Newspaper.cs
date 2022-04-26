using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Newspaper
    {
        public Newspaper()
        {
            NewsAds = new HashSet<NewsAd>();
        }

        public string CNewspaperCode { get; set; }
        public string CNewspaperName { get; set; }
        public string VRegion { get; set; }
        public string VTypeOfNewspaper { get; set; }
        public string VContactPerson { get; set; }
        public string VHoaddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public string CCountryCode { get; set; }
        public string CFax { get; set; }
        public string CPhone { get; set; }

        public virtual Country CCountryCodeNavigation { get; set; }
        public virtual ICollection<NewsAd> NewsAds { get; set; }
    }
}
