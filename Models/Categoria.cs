using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bicicletaMVC.Models
{
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }


        public ICollection<Bicicleta> Bicicleta { get; set; }

    }
}
