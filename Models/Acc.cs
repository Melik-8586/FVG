using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_fvg.Models
{
    public class Acc
    {
        public int Id { get; set; }
        public string Acc_code { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; }
    }
}
