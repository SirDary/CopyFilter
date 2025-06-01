using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class EmailModel
    {
        public string From { get; set; } = "from@email.da";
        public ICollection<string> To { get; set; } = [];
        public ICollection<string> Copy { get; set; } = [];
        public string BlindCopy { get; set; } = "";
        public string Title { get; set; } = "Title";
        public string Body { get; set; } = "Body";
    }
}
