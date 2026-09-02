using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bicicletaMVC.Models
{
    public class Bicicleta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BicicletaID { get; set; }       
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
        public int Precio { get; set; }
        public int CategoriaID { get; set; }



        public Categoria Categoria{ get; set; }
    }
}
