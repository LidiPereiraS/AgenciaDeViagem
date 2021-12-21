using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenciadeviagem.Models
{
    public class Destino
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Ciadade { get; set; }
        [Required]
        public string Horario { get; set; }
        [Required]
        public string Data { get; set; }

    }
}
