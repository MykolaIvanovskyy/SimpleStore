using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Store.Domain.Entities;
using Store.Domain.Abstract;

namespace Store.Domain.Concrete
{
    public  class EmailOrderProcessor: IOrderProcessor
    {
        private EmailSettings emaileSettings;
        public EmailOrderProcessor(EmailSettings setting)
        {
            this.emaileSettings = setting;
        }

        public void ProcessorOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emaileSettings.UseSsl;
                smtpClient.Host = emaileSettings.ServerName;
                smtpClient.Port = emaileSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emaileSettings.ServerName, emaileSettings.Password);

                if (emaileSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emaileSettings.Filelocation;
                    smtpClient.EnableSsl = false;

                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New order is processed")
                    .AppendLine("---")
                    .AppendLine("Products:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (In total: {2:c})", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("General price: {0:c}",cart.ComputerTotalValue())
                    .AppendLine("---")
                    .AppendLine("Delivery")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",shippingInfo.GiftWrap ? "Yes" : "No");

                MailMessage mailMassage = new MailMessage(
                    emaileSettings.MailFromAddress,
                    emaileSettings.MailToAddress,
                    "New order send",
                    body.ToString());

                if (emaileSettings.WriteAsFile)
                {
                    mailMassage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMassage);
            }

        }
    }
}
