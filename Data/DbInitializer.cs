using bicicletaMVC.Models;
using bicicletaMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bicicletaMVC.Data
{
    public static class DbInitializer
    {

        public static void Initialize(bicicletaMVCContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Bicicleta.Any())
            {
                return;   // DB has been seeded
            }



            //============================================
            //  Categorias
            //============================================

            var categorias = new Categoria[]
                        {
            new Categoria{CategoriaID=1,Nombre="Bicicleta de Carretera"},
            new Categoria{CategoriaID=2,Nombre="Bicicleta Electrica"},
            new Categoria{CategoriaID=3,Nombre="Bicicleta de Montaña"},

                        };
            foreach (Categoria c in categorias)
            {
                context.Categoria.Add(c);
            }
            context.SaveChanges();                                                                               
            
            

            //============================================
            //  Bicicletas
            //============================================
            var bicicletas = new Bicicleta[]
            {
                new Bicicleta{BicicletaID=1,Nombre="KTM Myroon Pro 12",Descripcion=" KTM Comp ST-92A, 7°",Precio=350,CategoriaID=1},
                new Bicicleta{BicicletaID=2,Nombre="Merida Big.Nine 40-D",Descripcion=" Merida CC 31.8 elevación 6º",Precio=499,CategoriaID=2},
                new Bicicleta{BicicletaID=3,Nombre="MMR Woki 29 WCS",Descripcion=" Ritchey Logic - 4 Axis 31.8",Precio=699,CategoriaID=3},
                new Bicicleta{BicicletaID=4,Nombre="Wilier Cento1 Hybrid",Descripcion="Fibra de carbono Monocasco60TON",Precio=3050,CategoriaID=1},
                new Bicicleta{BicicletaID=5,Nombre="Xiaomi Qicycle",Descripcion="Incluye ordenador a bordo, para monitorear tu pedaleo, fuerza, velocidad, distancia y consumo de calorías",Precio=863,CategoriaID=2},
                new Bicicleta{BicicletaID=6,Nombre="New Star ",Descripcion="6 velocidades fricción,acero con tuerca, triple plato",Precio=118,CategoriaID=3},
                new Bicicleta{BicicletaID=7,Nombre="Moma Bikes MTB GTT",Descripcion="profesional, Aluminio, Unisex Adulto, Negro , L (1,70-1,79 m)",Precio=219,CategoriaID=1},
                new Bicicleta{BicicletaID=8,Nombre="Chicco First Bike",Descripcion="Bicicleta sin pedales con sillín regulable, color rojo, 2-5 años",Precio=90,CategoriaID=2},
                new Bicicleta{BicicletaID=9,Nombre="F.lli Schiano Ghost",Descripcion="Women's, Antracita-Rojo, 26",Precio=139,CategoriaID=3},


            };
            foreach (Bicicleta b in bicicletas)
            {
                context.Bicicleta.Add(b);
            }
            context.SaveChanges();





            



            //============================================
            //  Bicicletas-Categoria
            //============================================
            //        var Bicicleta_Categoria = new Categoria[]
            //        {
            //        new Categoria{BicicletaID=5,CategoriaID=22},


            //        };
            //        foreach (Categoria e in Categoria)
            //        {
            //            context.Bicicleta.Add(e);
            //        }
            //        context.SaveChanges();

            //    //_____________________________________________________
            //}
        }
    }
}