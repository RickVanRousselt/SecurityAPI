using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CreateSubscription
{
    class Program
    {
        static void Main(string[] args)
        {
           ClientCredential cred = new ClientCredential("id", "secret"); 
            AuthenticationContext ctx = new AuthenticationContext("https://login.windows.net/af8499b5-4034-4c9a-8bd3-4db9f078cb21");
            AuthenticationResult res = ctx.AcquireTokenAsync("https://manage.office.com", cred).GetAwaiter().GetResult();



     //       HttpWebRequest req = HttpWebRequest.Create(
     //           "https://manage.office.com/api/v1.0/af8499b5-4034-4c9a-8bd3-4db9f078cb21/activity/feed/subscriptions/start?contentType=Audit.SharePoint") as HttpWebRequest;

     //       req.Headers.Add("Authorization", "Bearer " + res.AccessToken);
     //       req.ContentType = "application/json";
     //       req.Method = "POST";
     //       string hook =
     //           @"{'webhook' : {
     //  'address': 'https://securitytestkbcrick.azurewebsites.net/api/audit',
     //  'authId': 'o365eyskensnotificationaad',
     //  'expiration': ''}
     //}";
     //       req.ContentLength = hook.Length;
     //       using (var streamWriter = new StreamWriter(req.GetRequestStream()))
     //       {
     //           streamWriter.Write(hook);
     //           streamWriter.Flush();
     //           streamWriter.Close();
     //       }

            HttpWebRequest req = HttpWebRequest.Create(
                       "https://manage.office.com/api/v1.0/af8499b5-4034-4c9a-8bd3-4db9f078cb21/activity/feed/audit/20190222085303271115165$20190222085735223143584$audit_sharepoint$Audit_SharePoint$IsFromNotification$6") as HttpWebRequest;

            req.Headers.Add("Authorization", "Bearer " + res.AccessToken);
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var a = reader.ReadToEnd();
            }
        }


    }
}
