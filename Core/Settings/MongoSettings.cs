using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Settings
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
