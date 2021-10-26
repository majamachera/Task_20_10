using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Dtos
{
    public class ParticipantForUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Payed { get; set; }

    }
}
