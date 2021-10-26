using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Dtos
{
    public class ParticipantForReturnDto
    {
        [Key]
        public Guid ParticipantId { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }
        public Result Result { get; set; }
        public bool Payed { get; set; }
        public int Number { get; set; } //Ranom Number from 0-1000 to be printed on the participant shirt. 
        public Guid RaceId { get; set; }
    }
}
