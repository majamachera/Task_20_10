using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Dtos
{
    public class RaceDto
    {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Participant> Participants { get; set; }


    }
}
