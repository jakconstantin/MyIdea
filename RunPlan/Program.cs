
using Engine;
using Engine.PlanEngine;
using Idea.Youla;

namespace RunPlan
{
    class Program
    {
        public async Task<bool> Start(string[] args)
        {
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

            await planEngineBase.RunParse();


            //Plan plan = new Plan() { Id = Guid.NewGuid(), Name = "Test", SearchText = "Мотоцикл" };
            //string json = Utils.ToJsonText(plan);


            return true;
        }
    }
}
