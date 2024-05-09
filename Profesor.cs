using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Channels;

namespace Club
{
    public class Profesor : Persona
    {
        ushort legajo;
        Persona datos;

        public ushort Legajo { get => legajo; set => legajo = value; }
        public Persona Datos { get => datos; set => datos = value; }
        

        public Profesor(ushort legajo, Persona datos) : base(datos.Nombre, datos.Apellido, datos.TipoID, datos.NroID, datos.Domicilio)
        {
            Legajo = legajo;
            Datos = datos;
         }

        public override string ToString()
        {
            return "Legajo: " + Legajo + "\nDATOS PERSONALES: " + "\n" + Datos + "\n";
        }
    }
}