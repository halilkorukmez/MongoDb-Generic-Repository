using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Mongo
{
    public class Collection : Attribute
    {
        private string _name = "";

        public Collection(string name)
        {
            this._name = name;
        }

        public virtual string Name
        {
            get { return _name; }
        }
    }
}
