using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_20_10.Models
{
    public class Race
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Participant> Participants { get; set; }
        

    }
}
