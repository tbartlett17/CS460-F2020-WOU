﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW4Project.Models
{
    public class ColorInterpolation
    {
        [Required]
        public string FirstColor { get; set; }

        [Required]
        public string LastColor { get; set; }

        [Required]
        [Range(0,13)]
        public int? NumberOfColors { get; set; }
        public List<string> ColorList { get; set; }

        public override string ToString()
        {
            return $"firstColor={FirstColor}, LastColor={LastColor}, NumColors={NumberOfColors}"; ;
        }
    }
}
