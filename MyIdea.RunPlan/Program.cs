
using Engine;
using Engine.PlanEngine;
using MyIdea.Youla;
using MyIdea.Email;
using System.Text;
using MyIdea.Logger;
using System.Diagnostics;
using System.Reflection;
using MyIdea.RunPlan;
using MyIdea.Email.EmailBody;

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

            try
            {

                Plan plan = Utils.FromJsonText<Plan>(args[0]);
                if (string.IsNullOrEmpty(plan.Name))
                {
                    return false;
                }

                MyIdeaLogger.LogFileName = Plan.GetPlanLogName(plan.Id.ToString());
                
                Logger.Info("****************************************************************");
                Logger.InfoFormat("Starting plan Version: {0}", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
                
                PlanEngineBase planEngineBase;
                switch (plan.StoreType)
                {
                    case Engine.Enums.StoreType.Youla:
                        planEngineBase = new YoulaPlanEngine(plan);
                        break;
                    default:
                        throw new Exception(string.Format("Not support plan type: {0}", plan.StoreType));
                }

                var list = await planEngineBase.RunParse();

                EmailBodyHtml emailBodyHtml = new EmailBodyHtml();
                string emailBody =  emailBodyHtml.GetEmailBody(list);

                EmailService emailService = new EmailService();

                await emailService.SendEmailAsync(plan.Enail, string.Format("""Отчет "{0}" """, plan.SearchText), emailBody);

                //Plan plan = new Plan() { Id = Guid.NewGuid(), Name = "Test", SearchText = "Мотоцикл" };
                //string json = Utils.ToJsonText(plan);

                Logger.Info(string.Format("Plan finished. Version: {0}", FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion));                
                return true;
            }
            catch(Exception ex) 
            {
                Logger.Error(ex);
                return false;
            }

        }
    }
}
