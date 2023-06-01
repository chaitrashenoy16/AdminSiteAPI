
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AdminSiteAPI.Model
{
    public class User
    {
       public string id { get; set; }
        public string username { get; set; }
        public string companyid { get; set; }
        public string companyname { get; set; }
        public string userpermission { get; set; }
        public string usertype { get; set; }

    }
}
