using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using bicicletaMVC.Data;
using Microsoft.Extensions.DependencyInjection;

namespace bicicletaMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<bicicletaMVCContext>();
                    /*context.Database.EnsureCreated();*/
                    DbInitializer.Initialize(context);
                    //cBicicletaCarretera.Initialize(context);
                    //cBicicletaElectrica.Initialize(context);
                    //cBicicletaMontana.Initialize(context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }

            }
        }
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });


        //main========================================================================================




        //public static void Primero(string[] args)
        //{
        //    var host = Create1(args).Build();

        //    SinoE(host);

        //    host.Run();
        //}

        //private static void SinoE(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;

        //        try
        //        {
        //            var context = services.GetRequiredService<bicicletaMVCContext>();
        //            //context.Database.EnsureCreated();
        //            BicicletaCarretera.Initialize(context);

        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services.GetRequiredService<ILogger<Program>>();
        //            logger.LogError(ex, "An error occurred creating the DB.");
        //        }

        //    }
        //}

        //public static IHostBuilder Create1(string[] args) =>
        //   Host.CreateDefaultBuilder(args)
        //       .ConfigureWebHostDefaults(webBuilder =>
        //       {
        //           webBuilder.UseStartup<Startup>();
        //       });












        //    //2========================================================================================

        //    public static void Segundo(string[] args)
        //    {
        //        var host = Create2(args).Build();

        //        SinoE2(host);

        //        host.Run();
        //    }
        //    private static void SinoE2(IHost host)
        //    {
        //        using (var scope = host.Services.CreateScope())
        //        {
        //            var services = scope.ServiceProvider;

        //            try
        //            {
        //                var context = services.GetRequiredService<bicicletaMVCContext>();
        //                //context.Database.EnsureCreated();
        //                Montana.Initialize(context);

        //            }
        //            catch (Exception ex)
        //            {
        //                var logger = services.GetRequiredService<ILogger<Program>>();
        //                logger.LogError(ex, "An error occurred creating the DB.");
        //            }

        //        }
        //    }

        //    public static IHostBuilder Create2(string[] args) =>
        //      Host.CreateDefaultBuilder(args)
        //          .ConfigureWebHostDefaults(webBuilder =>
        //          {
        //              webBuilder.UseStartup<Startup>();
        //          });


        //    ////========================================================================================
        //    public static void Tercero(string[] args)
        //    {
        //        var host = Create3(args).Build();

        //    SinoE3(host);

        //    host.Run();
        //    }
        //private static void SinoE3(IHost host)
        //    {
        //        using (var scope = host.Services.CreateScope())
        //        {
        //            var services = scope.ServiceProvider;

        //            try
        //            {
        //                var context = services.GetRequiredService<bicicletaMVCContext>();
        //                //context.Database.EnsureCreated();
        //                Electrica.Initialize(context);

        //            }
        //            catch (Exception ex)
        //            {
        //                var logger = services.GetRequiredService<ILogger<Program>>();
        //                logger.LogError(ex, "An error occurred creating the DB.");
        //            }

        //        }
        //    }

        //    public static IHostBuilder Create3(string[] args) =>
        //      Host.CreateDefaultBuilder(args)
        //          .ConfigureWebHostDefaults(webBuilder =>
        //          {
        //              webBuilder.UseStartup<Startup>();
        //          });



    }
}






















//public static void Main(string[] args)
//{
//    CreateHostBuilder(args).Build().Run();

//}

//public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });
