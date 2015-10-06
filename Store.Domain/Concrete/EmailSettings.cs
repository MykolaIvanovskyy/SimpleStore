using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orderer@exampel.com";
        public string MailFromAddress = "productstore@examole.com";
        public bool UseSsl = true;
        public string UserName = "MySmtpUserName";
        public string Password = "MySmtpPasword";
        public string ServerName = "smtp.example.com";
        public short ServerPort = 578;
        public bool WriteAsFile = true;
        public string Filelocation = @"c:\product_store_emails";

    }
}
