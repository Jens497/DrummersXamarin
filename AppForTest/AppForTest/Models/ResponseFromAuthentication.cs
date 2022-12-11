using System;
using System.Collections.Generic;
using System.Text;

namespace AppForTest.Models
{
    //If any more messages or the likes is needed, can just be added.
    public class ResponseFromAuthentication
    {
        public string UserAccessToken { get; set; }
        public string UserName { get; set; }
        public bool IsFailed { get; set; }
        public string ErrorMessage { get; set; }
    }
}
