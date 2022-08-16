using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["signinpage_url"];
        public static readonly string OrderPageUrl = ConfigurationManager.AppSettings["orderpage_url"];
        public static readonly string EmailSignIn = ConfigurationManager.AppSettings["email_signin"];
        public static readonly string PasswordSignIn = ConfigurationManager.AppSettings["password_signin"];

    }
}
