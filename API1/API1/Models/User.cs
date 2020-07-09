using Microsoft.VisualBasic;
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
    public class User
    {

        public int UserId { get; set; }
        public string Username{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }

        public Perfil Perfil { get; set; }

        public int PerfilId { get; set; }

        public Microsservice Microsservice { get; set; }

        public int MicrosserviceId { get; set; }

        public ICollection<Occurrence> Occurrences { get; set; }

    }
}
