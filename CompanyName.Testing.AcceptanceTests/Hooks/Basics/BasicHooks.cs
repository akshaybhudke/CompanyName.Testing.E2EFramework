using BoDi;
using CompanyName.Testing.AcceptanceTests.Framework;
using CompanyName.Testing.AcceptanceTests.Framework.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CompanyName.Testing.AcceptanceTests.Hooks.Basics
{
    [Binding]
    public class BasicHooks
    {
        [BeforeTestRun(Order =1)]
        public static void BindJsonConfiguration(IObjectContainer container)
        {
            container.RegisterInstanceAs(Configuration.Get());
            Context.ContextData = new Dictionary<string, object>();
        }

        [BeforeTestRun(Order =5)]
        public static void CreateClearContextData() 
        {
            Context.ContextData = new Dictionary<string, object>();
        }

        [BeforeTestRun(Order = 10)]
        public static void InitializeNavigation()
        {
            NavigationHelper.AddNavigationData(NavigationMapping.NavigateToActions);
        }
    }
}
