using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_20_10.Dtos
{
    public class ResultForAddDto
    {
       

        public string Status { get; set; }
        public TimeSpan Time { get; set; } // The result of the race
        public Guid ParticipantId { get; set; }
    }
}
