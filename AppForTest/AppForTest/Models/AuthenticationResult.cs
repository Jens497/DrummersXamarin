using System;
using System.Collections.Generic;
using System.Text;

namespace AppForTest.Models
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public bool IsFailed { get; set; }
        public string ErrorMessage { get; set; }
    }
}
