using CompanyName.Testing.AcceptanceTests.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.PageContexts
{
    public static class BasePageContexts
    {
        public static async Task LogOut() 
        {
            await Context.CurrentPage.Navigation.SelectAccountMenuItem("Log Out");
            Context.CurrentUser = null;
        }
    }
}
