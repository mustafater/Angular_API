using Blog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendContactEmail(Contact contact)
        {
            
            try
            {
                MailMessage mailMessage = new MailMessage();

                SmtpClient smtpClient = new SmtpClient("smtp.live.com");

                mailMessage.From = new MailAddress("mustafa.ter@hotmail.com");
                mailMessage.To.Add("mustafa.ter@hotmail.com");

                mailMessage.Subject = contact.Subject;
                mailMessage.Body = contact.Message;
                mailMessage.IsBodyHtml = true;
                smtpClient.Port = 465;

                smtpClient.Credentials = new System.Net.NetworkCredential("mustafa.ter@hotmail.com", "3727467");

                smtpClient.Send(mailMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
