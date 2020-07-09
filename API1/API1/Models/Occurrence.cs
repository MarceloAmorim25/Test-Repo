using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Occurrence
    {
        public int OccurrenceId { get; set; }
        public int Origin { get; set; }
        public DateTime OccurrenceDate { get; set; }
        public string Details { get; set; }

        
        public Error Error { get; set; }
        public int ErrorId { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }


        public Environment Environment { get; set; }
        public int EnvironmentId { get; set; }

    }
}
