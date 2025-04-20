using ConfigLibrary.BL.Interfaces;
using ConfigLibrary.Extension;
using ConfigLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.Tests
{
    public class ConfigurationReaderTest
    {
        //lokal connection string, kendinize göre düzenlemeniz gerekmekte.
        private readonly string connStr = "Data source=.;initial catalog=ConfigDb;Trusted_Connection=True;TrustServerCertificate=True";

        [Fact]
        public async Task GetValue_ReturnValue()
        {
            var _configurationReader = new ConfigurationReader("SERVICE-A",connStr , 2000);

            Assert.Equal("soty.io", _configurationReader.GetValue("SiteName"));
        }

        [Fact]
        public async Task GetValue_WrongKey()
        {
            var _configurationReader = new ConfigurationReader("SERVICE-A", connStr, 3000);

            Assert.Null(_configurationReader.GetValue("Wrong Key"));

        }
         
        
    }
}
