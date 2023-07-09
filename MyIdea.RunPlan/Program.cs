
using Engine;
using Engine.PlanEngine;
using MyIdea.Youla;
using MyIdea.Email;
using System.Text;

namespace RunPlan
{
    class Program
    {
        public async Task<bool> Start(string[] args)
        {        
         
            //Plan plan1 = new Plan() { Id = Guid.NewGuid(), Name = "Test", SearchText = "Детская коляска", PriceMax=10000, PriceMin = 1000, StoreType = Engine.Enums.StoreType.Youla };
            //string json = Utils.ToJsonText(plan1);

            if (args.Count() == 0)
            {
                //Logger.ErrorFormat("CBBackupPlan started without arguments");
                //Console.WriteLine("Plan ID must be specified");
                return false;
            }


            Plan plan = Utils.FromJsonText<Plan>(args[0]);
            if (string.IsNullOrEmpty(plan.Name))
            {
                return false;
            }

            PlanEngineBase planEngineBase;
            switch (plan.StoreType)
            {
                case Engine.Enums.StoreType.Youla:
                    planEngineBase = new YoulaPlanEngine(plan);
                    break;
                default:
                    throw new Exception("");
            }

           var list =  await planEngineBase.RunParse();

//            < !DOCTYPE html >
//< html >
//< body >

//< h2 > HTML Image </ h2 >
//< img src = "img_chania.jpg" alt = "Flowers in Chania" width = "460" height = "345" >

//</ body >
//</ html >

//            <html>
// <head>
//  <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
//  <title>Ссылка</title>
// </head>
// <body> 
//   <p><a href="sample.html"><img src="images/sample.gif" width="50" 
//   height="50" alt="Пример"></a></p>
// </body> 
//</html>




            StringBuilder sb =  new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<body>");
            foreach (var item in list)
            {
                string s = string.Format("""<p><a href="{0}"><img src="{1}" width="100" height="100"></a></p>""", item.Url, item.Img);
                sb.AppendLine(s);               
            }
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");


            EmailService emailService = new EmailService();
            
            await emailService.SendEmailAsync(plan.Enail, string.Format("""Отчет "{0}" """, plan.SearchText), sb.ToString());

            //Plan plan = new Plan() { Id = Guid.NewGuid(), Name = "Test", SearchText = "Мотоцикл" };
            //string json = Utils.ToJsonText(plan);


            return true;
        }
    }
}
