using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.DataAccessTests.Utilities
{
    public static class ConnectionStringProvider
    {
        public static string GetConnectingString() => "Data Source=Data.sqlite";
    }
}
