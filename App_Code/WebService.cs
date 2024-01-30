using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService] 
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string MailSend(string name, string email, string message)
    {
        string msg = "" ;
        try
        {
            
            var fromAddress = new MailAddress("no-reply@connecton.com.pk", "Connecton Query");
            string fromPassword = "connecton123@@";
            var toAddress = new MailAddress("info@connecton.com.pk");
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "mail.connecton.com.pk",
                Port = 25,
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("no-reply@connecton.com.pk", fromPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var message1 = new MailMessage(fromAddress, toAddress);
            message1.Subject = "Connecton Query";
            message1.Body = "Name : " + name + " | Email : " + email + " | Message : " + message;
            message1.IsBodyHtml = true;
            smtp.Send(message1);
            msg = "Your request has been sent successfully!";

        }
        catch(Exception ex)
        {
            msg = ex.Message;//"Your request has been denied. please send again.";
        }
        return msg;
    }
    
}
