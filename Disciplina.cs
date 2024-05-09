using System;
using System.Collections.Generic;
using System.Text;

namespace Club
{
   public class Disciplina
    {
        private string nomDisciplina;
        private Profesor profe;
        private const byte cantAlumnos = 30;
        private double valorCuotaSocio;
        private double valorCuotaNoSocio;
        private byte vacante = cantAlumnos;
        private bool cupo;
       
        public string NomDisciplina { get => nomDisciplina; set => nomDisciplina = value; }
        public static byte CantAlumnos => cantAlumnos;
        internal Profesor Profe { get => profe; set => profe = value; }
        public double ValorCuotaSocio { get => valorCuotaSocio; set => valorCuotaSocio = value; }
        public double ValorCuotaNoSocio { get => valorCuotaNoSocio; set => valorCuotaNoSocio = value; }
        public byte Vacante { get => vacante; set => vacante = value; }
        public bool Cupo { get => cupo; set => cupo = value; }
       
        

        public Disciplina( string nomDis, Profesor profe, double valSocio, double valNoSoc, byte vacantes, bool cupo)
        {
            NomDisciplina = nomDis;
            Profe = profe;
            ValorCuotaSocio = valSocio;
            ValorCuotaNoSocio = valNoSoc;
            Vacante = vacantes;
            Cupo = cupo;
        
            }

        public override string ToString()
        {
            return $"Actvidad: {NomDisciplina} Profesor a cargo: {Profe} Valor mensual: {ValorCuotaSocio},  Valor clase única: {ValorCuotaNoSocio} Vacantes disponibles: {Vacante}"
             ;

        }
    }
}
       

   
