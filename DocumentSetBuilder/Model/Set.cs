using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSetBuilder.Model
{
    public class Set
    {
        public List<String> TestSet { get; set; }
        public List<String> TrainingSet { get; set; }

        public Set()
        {
            TestSet = new List<string>();
            TrainingSet = new List<string>();
        }

    }
}
