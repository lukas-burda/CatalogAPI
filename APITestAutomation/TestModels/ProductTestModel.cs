using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAutomation.TestModels
{
    class ProductTestModel
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }

        public ProductTestModel() { }

        public ProductTestModel(Guid id, string code, string name)
        {
            this.id = id.ToString();
            this.code = code;
            this.name = name;
        }
    }
}
