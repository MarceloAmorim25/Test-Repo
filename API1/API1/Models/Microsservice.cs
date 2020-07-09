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
    public class Microsservice
    {

        public int MicrosserviceId { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
