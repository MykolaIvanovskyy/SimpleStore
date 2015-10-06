using Store.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Store.WebUI.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticete(string userName, string userPassword)
        {
            bool result = FormsAuthentication.Authenticate(userName, userPassword);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);               
            }
            return result;
        }
    }
}