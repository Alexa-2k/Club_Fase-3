using System;
using System.Collections.Generic;
using System.Text;

namespace Club
{
public class Persona
    {

        private string nombre, apellido, tipoID, nroID;
        Domicilio domicilio;
        public Persona(string nombre, string apellido, string tipoID, string nroID, Domicilio domicilio)
        {
            Nombre = nombre;
            Apellido = apellido;
            TipoID = tipoID;
            NroID = nroID;
            Domicilio = domicilio;
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string TipoID
        {
            get { return tipoID; }
            set { tipoID = value; }
        }

        public string NroID
        {
            get { return nroID; }
            set { nroID = value; }
        }
        internal Domicilio Domicilio { get => domicilio; set => domicilio = value; }

        public override string ToString()
        {
            return "Apellido y Nombre:  " + Apellido + ", " + Nombre + " \nTipo y numero ID: " + TipoID + " " + NroID + "\n" + Domicilio + "\n";
        }
        


    }
}
