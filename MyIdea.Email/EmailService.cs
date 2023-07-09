using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MyIdea.Email
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Парсер сайта", GetText("bTBiaWxlcGV5bWVudGluZm9AeWFuZGV4LnJ1")));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.yandex.ru", 25, false);
                    await client.AuthenticateAsync(GetText("bTBiaWxlcGV5bWVudGluZm9AeWFuZGV4LnJ1"), GetText("MXFhelhTV0AzZWRjVkZSJA=="));
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                { 
                }
            }
        }


        private string GetText(string text)
        {
            var enTextBytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(enTextBytes);
        }
    }
}