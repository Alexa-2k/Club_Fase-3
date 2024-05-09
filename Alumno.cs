using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Club
{
public class Alumno : Persona

    {
        private ushort nroSocio = 0;   //  si no es socio, nro de socio queda en 0
        private Persona identidad;      // toma los datos personales de clase Persona (nombre, apellido, DNI, domicilio)
        //Fase 2: modificamos la definicion de disciplinas para permitir que el alumno elija hasta 3
        public List<Disciplina> Actividades { get; set; } = new List<Disciplina>();
        private bool inhibido;          // indica si está inhibido por falta de pago
        private DateTime? venceCuota;
        private Pago pago;
        private bool aptoFisico;
        private bool carnet = false;

        public ushort NroSocio { get => nroSocio; set => nroSocio = value; }
        public bool Inhibido { get => inhibido; set => inhibido = value; }
        public DateTime? VenceCuota { get => venceCuota; set => venceCuota = value; }
        public Pago Pago { get => pago; set => pago = value; }
        public Persona Identidad { get => identidad; set => identidad = value; }
        public bool AptoFisico { get => aptoFisico; set => aptoFisico = value; }
        public bool Carnet { get => carnet; set => carnet = value; }
//        public List<Disciplina> Actividades1 { get => Actividades; set => Actividades = value; }

        public Alumno(ushort nroSocio, Persona identidad, List<Disciplina> actividades, bool aptoFisico, bool carnet , bool inhibido, DateTime? venceCuota, Pago pago ) : base(identidad.Nombre, identidad.Apellido, identidad.TipoID, identidad.NroID, identidad.Domicilio)
        {
            NroSocio = nroSocio;
            Identidad = identidad;
            Actividades = actividades ?? new List<Disciplina>();
            Inhibido = inhibido;
            VenceCuota = venceCuota;
            Pago = pago ;
            AptoFisico = aptoFisico;
            Carnet = carnet;
       
      }
        public static List<Alumno> ListadoSocios = new List<Alumno>();
        public static List<Alumno> ListaNOSocios = new List<Alumno>();
       
        public static List<Alumno> AlumnosConVencimientoHoy = new List<Alumno>();
       

//----------------------------------------------------
        public void RegistrarSocios(Alumno nuevoAlumno)
        {
           if (nuevoAlumno.NroSocio != 0)
            {
                carnet = true;                      //se entrega carnet al momento de registrarse
                ListadoSocios.Add(nuevoAlumno);
                Console.WriteLine($"INSCRIPCIÓN REGISTRADA \n Socio Nro: {nroSocio} \n {Apellido},{Nombre} \n{Domicilio} \n Carnet entregado.\n \n");
                
            } else
            {
                ListaNOSocios.Add(nuevoAlumno);  
                Console.WriteLine($"INSCRIPCIÓN REGISTRADA \n  {Apellido},{Nombre} \n {TipoID} {NroID} \n{Domicilio} \n \n");
                //los No socios no reciben carnet ni nro. Socio
            }
        }
        //---------------------------------------------        
        public void ElegirActividades(ushort socio, List<Disciplina> actividadesDisponibles)
        {
            byte cantActividades = 0;

            if (socio != 0) {
                cantActividades = 3;
                Console.WriteLine($"\n{Apellido}, {Nombre}: Seleccione hasta 3 actividades, ingrese 0 para finalizar su elección:");

            } else
            {
                cantActividades = 1;
                Console.WriteLine($"\n{Apellido}, {Nombre}: Seleccione 1 actividad, ingrese 0 para salir sin optar por una actividad:");
            }
            

            // Ciclo FOR desde 0 hasta la última actividad disponible, que muestra el listado de actividades con
            // un número de orden para que el usuario elija el nro de actividad
            for (byte i = 0; i < actividadesDisponibles.Count; i++)
            {
                // Verifica si hay vacantes en la actividad actual
                if (actividadesDisponibles[i].Vacante > 0)
                {
                    Console.WriteLine($"{i + 1}. {actividadesDisponibles[i].NomDisciplina}");
                }
                else
                {
                    Console.Write("");
                }
            }
            Console.WriteLine("0. Finalizar elección" + "\n");

            // Nueva lista en la que se adicionan los cursos seleccionados
            List<int> seleccionados = new List<int>();
            int opcion;

            //Inicializamos la primera opción fuera del bucle
           
            bool esPrimeraOpcion = true;


            // Mientras la cantidad de elegidos sea menor que 3, 

            while (seleccionados.Count < cantActividades)
            {
                Console.Write("\nIngrese el número de su opción, o 0 para terminar: \n");
            
                bool esNumero = Int32.TryParse(Console.ReadLine(), out opcion);

            // Se verifica si el nro de actividad ingresado es válido

                if (!esNumero)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                //Si la opción es 0 se da por terminada la elección

                if (opcion == 0)
                {
                    break; // Termina el bucle si el usuario ingresa 0
                }

                //se verifica si la opción ya fue seleccionada por el socio, y en ese caso se pide nueva opción
                if (opcion > 0 && opcion <= actividadesDisponibles.Count)
                {
                   if (seleccionados.Contains(opcion))
                    {
                        Console.WriteLine("\nATENCIÓN: Ya ha seleccionado esa opción. Por favor, elija otra.");
                        continue;
                    }

                    if (opcion > 0 && opcion <= actividadesDisponibles.Count)
                    {
                        // Verifica si la actividad aún tiene vacantes disponibles

                        if (actividadesDisponibles[opcion - 1].Vacante <= 0)
                        {
                            Console.WriteLine("\nATENCIÓN: Esa actividad ya no tiene vacantes disponibles. Por favor, elija otra.");
                            continue;
                        }
                                                                       
                        // Añade la opción a la lista de seleccionados
                        seleccionados.Add(opcion);

                        // Actualiza el atributo Cupo de la actividad seleccionada
                        actividadesDisponibles[opcion - 1].Cupo = actividadesDisponibles[opcion - 1].Vacante > 0;
                       
                    }
                    else 
                    { 
                        // Si la opcion ingresada es invalida, se da aviso

                        Console.WriteLine("\nOpción inválida");
                    }
                }

                //Se listan las opciones seleccionadas con sus detalles
                Console.WriteLine("\n \nHa seleccionado:\n");
                foreach (var seleccion in seleccionados)
                {
                    {
                        Console.WriteLine($"{actividadesDisponibles[seleccion - 1].NomDisciplina} \nProfesor: {actividadesDisponibles[seleccion - 1].Profe.Apellido}, {actividadesDisponibles[seleccion - 1].Profe.Nombre}\n - Valor mensual: $ {actividadesDisponibles[seleccion - 1].ValorCuotaSocio}\n - Valor clase individual $: {actividadesDisponibles[seleccion - 1].ValorCuotaNoSocio}\n  ");
                    }
                }
            }
               
                Actividades = seleccionados.Select(index => actividadesDisponibles[index - 1])
                                    .Where(a => a.Vacante > 0)
                                    .ToList();
                Console.Write("\n");

            } //fin elegiractividad

        //-------------------------------------------------

        public static void MostrarSocios()
        {
            Console.WriteLine("\n LISTADO DE SOCIOS \n");
            Console.WriteLine("------------------------------ \n");

            foreach (var alumno in ListadoSocios)
            {
                Console.WriteLine(alumno);
                Console.WriteLine("-----------------------------\n");

            }

            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
//----------------------------------------------------
       public static void MostrarNOSocios()
        {
            Console.WriteLine("\n LISTADO DE NO SOCIOS \n");
            Console.WriteLine("------------------------------ \n");

            foreach (var alumno in ListaNOSocios)
            {
                Console.WriteLine(alumno);
                Console.WriteLine("-----------------------------\n");
            }
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public static void VerificarVencimiento()
        {
            Console.WriteLine("\n LISTADO DE SOCIOS CUYA CUOTA VENCE HOY \n");
            Console.WriteLine("--------------------------------------------- \n");

            foreach (var alumno in ListadoSocios)
            {
                if (alumno.VenceCuota?.Date == DateTime.Today)
                {
                    AlumnosConVencimientoHoy.Add(alumno);
                    Console.WriteLine(alumno);
                    Console.WriteLine("-----------------------------\n");
                }
            }
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

//------------------------------------------

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nro.Socio: " + NroSocio);
            sb.AppendLine("\nDATOS PERSONALES:");

            // Accediendo a los atributos de Identidad
            sb.AppendLine($"Nombre: {Identidad.Nombre}");
            sb.AppendLine($"Apellido: {Identidad.Apellido}");
            sb.AppendLine($"Tipo ID: {Identidad.TipoID}");
            sb.AppendLine($"Número ID: {Identidad.NroID}");
            sb.AppendLine($"Dirección: {Identidad.Domicilio.Calle} {Identidad.Domicilio.Numero}   ({Identidad.Domicilio.Cp}) {Identidad.Domicilio.Ciudad}");

            sb.AppendLine("\nACTIVIDADES ELEGIDAS:");

            foreach (var actividad in Actividades)
            {
                sb.AppendLine($"- {actividad.NomDisciplina}");
            }

            sb.AppendLine($"Apto Físico: {AptoFisico}");
            sb.AppendLine($"Inhibido: {Inhibido}");
            sb.AppendLine($"Carnet entregado: {Carnet}");
            sb.AppendLine($"Vencimiento cuota: {VenceCuota}");

            return sb.ToString();
        }
       
    }
}
