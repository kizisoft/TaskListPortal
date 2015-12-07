namespace TaskListPortal.MVC.App_Start
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            viewEngines.Add(new RazorViewEngine());
        }
    }
}