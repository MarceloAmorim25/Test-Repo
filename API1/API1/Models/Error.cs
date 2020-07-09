using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; } = new List<Occurrence>();

    }
}
