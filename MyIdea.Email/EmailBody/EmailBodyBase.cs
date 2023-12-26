using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.Email.EmailBody
{
    public abstract class EmailBodyBase
    {
        public abstract string GetEmailBody(List<IResult> listResult);
    }
}
