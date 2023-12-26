using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.Email.EmailBody
{
    public class EmailBodyHtml : EmailBodyBase
    {
        public override string GetEmailBody(List<IResult> listResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<body>");
            foreach (var item in listResult)
            {
                string s = string.Format("""<p><a href="{0}"><img src="{1}" width="100" height="100"></a></p>""", item.Url, item.Img);
                sb.AppendLine(s);
            }
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
