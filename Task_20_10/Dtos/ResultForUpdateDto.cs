using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_20_10.Dtos
{
    public class ResultForUpdateDto
    {
       

        public string Status { get; set; }
        public TimeSpan Time { get; set; } 
    }
}
