using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSG.Kaveri.UserLoginAPI.Models
{
    public class UserLoginResponse
    {
        public int citizenid { get; set; }
        public String loginname { get; set; }
        public String firstname { get; set; }
        public String middlename { get; set; }
        public String lastname { get; set; }
        public String email { get; set; }
        public int phone { get; set; }
        public int responseCode { get; set; }
        public String responseMessage {get; set;}
    }
}