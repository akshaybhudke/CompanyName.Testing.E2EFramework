using CompanyName.Testing.AcceptanceTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.Testing.AcceptanceTests.Framework
{
    public static class Context
    {
        public static BasePage CurrentPage { get; set; }
        public static string CurrentUser { get; set; }
        public static Dictionary<string, object> ContextData { get; set; }
    }
}
