using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Perfil
    {
        public int PerfilId { get; set; }

        public string Type { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
