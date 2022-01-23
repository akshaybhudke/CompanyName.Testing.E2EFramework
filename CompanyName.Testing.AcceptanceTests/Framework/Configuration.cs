using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CompanyName.Testing.AcceptanceTests.Framework
{
    public class Configuration
    {
        private static readonly string EnvName =
            Environment.GetEnvironmentVariable("SMOKE_TEST_ENVIRONMENT" ?? "dev");

        public string BaseUrl { get; set; }

        public List<UserData> UserData { get; set; }

        public static Configuration Get() {

            var configuration = new Configuration();

            new ConfigurationBuilder()
                .AddJsonFile($"testdata.{EnvName}.json", optional: false)
                .Build()
                .Bind(configuration);
            return configuration;
        }

    }
}