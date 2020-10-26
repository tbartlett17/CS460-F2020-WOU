using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4Project.Models
{
    public class ColorInterpolation
    {
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public int? NumberOfColors { get; set; }
        public List<string> ColorList { get; set; }

        public override string ToString()
        {
            return $"firstColor={FirstColor}, secondColor={SecondColor}, NumColors={NumberOfColors}"; ;
        }
    }
}
