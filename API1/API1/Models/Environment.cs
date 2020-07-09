using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Environment
    {

        [Key, Required]
        public int EnvironmentId { get; set; }
        public string Phase { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; } = new List<Occurrence>();

    }
}
