using System;
using System.Collections.Generic;

namespace LiquidacionHaberes
{

    // 1. ENCAPSULAMIENTO Y CLASE BASE ABSTRACTA

    public abstract class Empleado
    {
        // Propiedades encapsuladas
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public decimal SueldoBase { get; set; }

        protected Empleado(string nombre, string dni, decimal sueldoBase)
        {
            Nombre = nombre;
            Dni = dni;
            SueldoBase = sueldoBase;
        }

        // POLIMORFISMO: Método virtual que será redefinido por las clases hijas
        public virtual decimal CalcularPagoFinal()
        {
            return SueldoBase;
        }
    }


    // 2. HERENCIA: Vendedor hereda de Empleado

    public class Vendedor : Empleado
    {
        public decimal Comisiones { get; set; }

        public Vendedor(string nombre, string dni, decimal sueldoBase, decimal comisiones)
            : base(nombre, dni, sueldoBase)
        {
            Comisiones = comisiones;
        }

        // POLIMORFISMO: Suma sus comisiones al sueldo base
        public override decimal CalcularPagoFinal()
        {
            return SueldoBase + Comisiones;
        }
    }


    // 3. HERENCIA: Directivo hereda de Empleado

    public class Directivo : Empleado
    {
        public decimal Bono { get; set; }

        public Directivo(string nombre, string dni, decimal sueldoBase, decimal bono)
            : base(nombre, dni, sueldoBase)
        {
            Bono = bono;
        }

        // POLIMORFISMO: Suma su bono al sueldo base
        public override decimal CalcularPagoFinal()
        {
            return SueldoBase + Bono;
        }
    }


    // 4. PROGRAMA PRINCIPAL

    class Program
    {
        static void Main(string[] args)
        {
            // PROCESAMIENTO DE LISTA MIXTA
            List<Empleado> personal = new List<Empleado>()
            {
                new Vendedor("Carlos Pérez", "30123456", 500000, 150000),
                new Directivo("Ana Gómez", "25987654", 1200000, 350000),
                new Vendedor("Laura Martínez", "35111222", 520000, 80000),
                new Directivo("Roberto Sánchez", "20555444", 1500000, 500000)
            };

            Console.WriteLine("        LIQUIDACION DE HABERES DEL PERSONAL       ");
            Console.WriteLine("              ");

            // POLIMORFISMO EN ACCIÓN:
            // Recorremos la lista procesando el monto a depositar de cada uno
            foreach (var emp in personal)
            {
                decimal montoADepositar = emp.CalcularPagoFinal();
                Console.WriteLine($"Empleado: {emp.Nombre,-16} | DNI: {emp.Dni} | Monto a depositar: ${montoADepositar:N2}");
            }

        }
    }
}
