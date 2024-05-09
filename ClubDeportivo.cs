using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Club
{
    internal class ClubDeportivo
    {
        public static void Main(string[] args)
        {
            // Creamos una instancia de alumno nuevo.
            // Primero generamos instancias de disciplina y profesor para tener los datos disponibles para el alumno 

            //Para crear al profesor creamos domicilio y persona:



            Domicilio domJoseRodriguez = new Domicilio
            {
                Calle = "Calle Falsa",
                Ciudad = "San Isidro",
                Cp = "B1642",
                Numero = 123,
                Telefono = 1147777777
            };

            // Instancia de persona profesoe

            Persona JoseRodriguez = new Persona("José", "Rodriguez", "DNI", "20000000", domJoseRodriguez);

            // instancia de profesor
            ushort legajo = 12345;
            Profesor profeSpinning = new Profesor(legajo, JoseRodriguez);

            //-------------------------------------------
            // Instancia de persona profesor

            Persona MartinRodriguez = new Persona("Martin", "Rodriguez", "DNI", "55555555", new Domicilio()
            {
                Calle = "Calle 1",
                Numero = 3453,
                Cp = "C1003",
                Ciudad = "Buenos Aires",
                Telefono = 1199999999
            });

            // instancia de profesor
            legajo = 22233;
            Profesor profeNatacion = new Profesor(legajo, MartinRodriguez);

            //------------------------------------------------------

            Persona GabrielInzua = new Persona("Gabriel", "Insua", "DNI", "56666666", new Domicilio()
            {
                Calle = "Av Santa Fe",
                Numero = 1070,
                Cp = "C1005",
                Ciudad = "Buenos Aires",
                Telefono = 1198888888
            });

            // instancia de profesor
            legajo = 00011;
            Profesor profeMusculacion = new Profesor(legajo, GabrielInzua);


            //------------------------------------------------------

            Persona NicolasMartinez = new Persona("Nicolas", "Martinez", "DNI", "65555555", new Domicilio()
            {
                Calle = "Av Córdoba",
                Numero = 3455,
                Cp = "C1038",
                Ciudad = "Buenos Aires",
                Telefono = 1197777777
            });

            // instancia de profesor
            legajo = 06500;
            Profesor profeEntrenamiento = new Profesor(legajo, NicolasMartinez);


            //------------------------------------------------------

            Persona MacarenaRossi = new Persona("Macarena", "Rossi", "DNI", "66555665", new Domicilio()
            {
                Calle = "Av Triunvirato",
                Numero = 4782,
                Cp = "C1419",
                Ciudad = "Buenos Aires",
                Telefono = 1195739753
            });

            // instancia de profesor
            legajo = 02753;
            Profesor profeAcquagym = new Profesor(legajo, MacarenaRossi);


            //------------------------------------------------------

            Persona VeronicaSanchez = new Persona("Veronica", "Sanchez", "DNI", "54545545", new Domicilio()
            {
                Calle = "Austria",
                Numero = 1275,
                Cp = "C1015",
                Ciudad = "Buenos Aires",
                Telefono = 1195557777
            });

            // instancia de profesor
            legajo = 03579;
            Profesor profeAtletismo = new Profesor(legajo, VeronicaSanchez);


            //------------------------------------------------------

            Persona MartinaVieyra = new Persona("Martina", "Vieyra", "DNI", "63097531", new Domicilio()
            {
                Calle = "Azcuénaga",
                Numero = 1853,
                Cp = "C1029",
                Ciudad = "Buenos Aires",
                Telefono = 1192004875
            });

            // instancia de profesor
            legajo = 10025;
            Profesor profePilates = new Profesor(legajo, MartinaVieyra);


            //------------------------------------------------------

            Persona SantiagoGiusti = new Persona("Santiago", "Giusti", "DNI", "75555555", new Domicilio()
            {
                Calle = "Av Jujuy",
                Numero = 345,
                Cp = "C1063",
                Ciudad = "Buenos Aires",
                Telefono = 1195732541
            });

            // instancia de profesor
            legajo = 32540;
            Profesor profeCardio = new Profesor(legajo, SantiagoGiusti);

            //------------------------------------------------------
            Persona CarolinaAraoz = new Persona("Carolina", "Araoz", "DNI", "68777556", new Domicilio()
            {
                Calle = "Av Pueyrredon",
                Numero = 2301,
                Cp = "C1035",
                Ciudad = "Buenos Aires",
                Telefono = 1197654321
            });

            // instancia de profesor
            legajo = 01423;
            Profesor profeYoga = new Profesor(legajo, CarolinaAraoz);


            //=====================================

            //Se crean nuevas instancias de la Clase Disciplina 
            // Instancia de Disciplina

            List<Disciplina> actividadesDisponibles = new List<Disciplina>()
            {
            new Disciplina("Spinning", profeSpinning, 12000.0, 4000, 2, true),
            new Disciplina("Natación", profeNatacion, 15000.0, 5000, 0, false),
            new Disciplina("Musculación", profeMusculacion, 12000.0, 4000, 30, true),
            new Disciplina("Entrenamiento libre", profeEntrenamiento, 12000.0, 4000, 30, true),
            new Disciplina("Acqua Gym", profeAcquagym, 15000.0, 5000, 30, true),
            new Disciplina("Atletismo", profeAtletismo, 12000.0, 4000, 30, true),
            new Disciplina("Pilates", profePilates, 12000.0, 4000, 30, true),
            new Disciplina("Cardio", profeCardio, 12000.0, 4000, 30, true),
            new Disciplina("Yoga", profeYoga, 10000.0, 3500, 30, true)
            };


            //========================================
            // REGISTRO 

            //Instanciamos alumnos: 

            // Instancia de persona
            Persona JuanPerez = new Persona("Juan", "Perez", "DNI", "12345678",
            new Domicilio()

            {
                Calle = "Calle Falsa",
                Numero = 1234,
                Ciudad = "Buenos Aires",
                Cp = "C1001",
                Telefono = 1112345678
            });

            // Registro : Instancia de Alumno socio con los datos de Persona JuanPerez
            Alumno Soc12345 = new Alumno(
            nroSocio: 12345,
            identidad: JuanPerez,
            actividades: null,
            aptoFisico: true,
            carnet: false,
            inhibido: false,
            venceCuota: DateTime.Now.AddMonths(1),   //se registra hoy Y PAGA HOY, la cuota vence dentro de un mes
            pago: new Pago(null,null, null, "0", null)  // todavía no pagó
                    );
            
            
            //Llamado al método que registra al alumno
            Soc12345.RegistrarSocios(Soc12345);
            
            //llamado al método que le permite elegir actividades
            Soc12345.ElegirActividades(Soc12345.NroSocio, actividadesDisponibles);

            //Registro del pago
            Pago pagoSoc12345 = new Pago(null, null, null, "0", null);
            pagoSoc12345.RegistrarPago(Soc12345, Soc12345.Actividades);
            


            //------------------------------------------------

            Persona JuanMartin = new Persona("Juan", "Martin", "Pasaporte", "AAB281830",
            new Domicilio()

            {
                Calle = "Fantasía",
                Numero = 257,
                Ciudad = "Buenos Aires",
                Cp = "C1439",
                Telefono = 1123456789
            });

            //Siguiente instancia

            // Registro : Instancia de Alumno socio con los datos de Persona JuanMartin
            Alumno Soc23456 = new Alumno(
            nroSocio: 23456,
            identidad: JuanMartin,
            actividades: null,
            aptoFisico: true,
            carnet: false,
            inhibido: false,
            venceCuota: DateTime.Now,
             pago: new Pago(null, null, null, "0", null)  // todavía no pagó
            );

            Soc23456.RegistrarSocios(Soc23456);
            Soc23456.ElegirActividades(Soc23456.NroSocio, actividadesDisponibles);

            Pago pagoSoc23456 = new Pago(null, null, null, "0", null);
            pagoSoc23456.RegistrarPago(Soc23456, Soc23456.Actividades);
            
            
            //-----------------------------------
            //Siguiente instancia

            Persona SolSchmidt = new Persona("Sol", "Schmidt", "DNI", "87654321",
                        new Domicilio()

                        {
                            Calle = "Callecita",
                            Numero = 4321,
                            Ciudad = "Buenos Aires",
                            Cp = "C1324",
                            Telefono = 1176542314
                        });

            // Registro : Instancia de Alumno socio con los datos de Persona SolSchmidt
            Alumno Soc65432 = new Alumno(
            nroSocio: 65432,
            identidad: SolSchmidt,
            actividades: null,
            aptoFisico: true,
            carnet: false,
            inhibido: false,
            venceCuota: DateTime.Now.AddDays(10),
            pago: new Pago(null, null, null, "0", null)  // todavía no pagó
            );

            Soc65432.RegistrarSocios(Soc65432);
            Soc65432.ElegirActividades(Soc65432.NroSocio,actividadesDisponibles);
            Pago pagoSoc65432 = new Pago(null, null, null, "0", null);
            pagoSoc65432.RegistrarPago(Soc65432, Soc65432.Actividades);
            
            //---------------------------------------------------

            //Siguiente instancia

            Persona GonzaloLopez = new Persona("Gonzalo", "Lopez", "DNI Extranjero", "99999999",
                        new Domicilio()

                        {
                            Calle = "Avenida",
                            Numero = 3333,
                            Ciudad = "Buenos Aires",
                            Cp = "C1222",
                            Telefono = 1199999999
                        });

            // Registro : Instancia de Alumno socio
            Alumno Soc11111 = new Alumno(
            nroSocio: 11111,
            identidad: GonzaloLopez,
            actividades: null,
            aptoFisico: true,
            carnet: false,
            inhibido: false,
            venceCuota: DateTime.Now,
           pago: new Pago(null, null, null, "0", null)  // todavía no pagó

            );

            Soc11111.RegistrarSocios(Soc11111);
            Soc11111.ElegirActividades(Soc11111.NroSocio, actividadesDisponibles);
            Pago pagoSoc11111 = new Pago(null, null, null, "0", null);
            pagoSoc11111.RegistrarPago(Soc11111, Soc11111.Actividades);
            
            //----------------------------------------------------------
            //Nuevo alumno, NO socio

            Persona DNIE98765432 = new Persona("Andrea", "Gonzalez", "DNI Extranjero", "98765432",
                 new Domicilio()

                 {
                     Calle = "Calle 4",
                     Numero = 456,
                     Ciudad = "Buenos Aires",
                     Cp = "C1020",
                     Telefono = 1198765432
                 }
                 );

            // Registro: Instancia de Alumno NO socio con los datos de Persona Andrea Gonzalez

            Alumno NSE98765432 = new Alumno(
            nroSocio: 0,
            identidad: DNIE98765432,
            actividades: null,
            aptoFisico: true,
            carnet: false,       // a los no socios no se les entrega carnet.
            inhibido: true,   //todavía no pagó, está inhibida

            venceCuota: DateTime.Now,  // como no es socia, paga las clases día a día. Paga hoy y el vencimiento es hoy
            pago: new Pago(null, null, null, "0", null)  // todavía no pagó

            );

            NSE98765432.RegistrarSocios(NSE98765432);
            NSE98765432.ElegirActividades(NSE98765432.NroSocio, actividadesDisponibles);
            
            //Registro del pago de Andrea Gonzalez
            Pago pagoNSE98765432 = new Pago(null, null, null, "0", null);
            pagoNSE98765432.RegistrarPago(NSE98765432, NSE98765432.Actividades);

            //======================================================

            //Mostrar listado de no socios
            Alumno.MostrarSocios();
            Console.WriteLine("\n");

            Alumno.MostrarNOSocios();
            Console.WriteLine("\n");

            //Mostrar listado de  socios

            

            
            //Listado de alumnos cuya cuota vence hoy. 

            Alumno.VerificarVencimiento();





        }  // Fin del Main

    }


}
   