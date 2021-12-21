using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenciadeviagem.Models
{
    public class Home
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Promocao { get; set; }
        [Required]
        public string Preco { get; set; }
        [Required]
        public int ContatoID { get; set; }
        public Contato Contato { get; set; }
        [Required]
        public int DestinoID { get; set; }
        public Destino Destino { get; set; }
    }
}


