using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Builder : IBuilder
    {
        public IObject Result { get; set; }
        public Builder(IObject obj) 
        {
            Result = obj;
        }
        public void SetProperty(string name, object value)
        {
            Result.SetProperty(name, value);
        }
    }
}
