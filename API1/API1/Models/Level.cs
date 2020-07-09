using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Level
    {
        public int LevelId { get; set; }
        public string ErrorType { get; set; }
        public ICollection<Error> Errors { get; set; } = new List<Error>();

    }
}
