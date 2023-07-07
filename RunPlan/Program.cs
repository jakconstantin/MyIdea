
using Engine;
using Engine.PlanEngine;
using Idea.Youla;
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
            StringBuilder sb =  new StringBuilder ();
            foreach (var item in list)
            { 
                sb.AppendLine(item.Url);
            }
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("jakconstantin@gmail.com", "Report", sb.ToString());

            //Plan plan = new Plan() { Id = Guid.NewGuid(), Name = "Test", SearchText = "Мотоцикл" };
            //string json = Utils.ToJsonText(plan);


            return true;
        }
    }
}
