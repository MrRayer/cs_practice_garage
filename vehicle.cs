using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garage_cspractice
{
    internal class vehicle
    {
        public string owner;
        public string owner_dni;
        public string type;
        private string patent;
        private string mode;
        private int in_time;
        private int out_time;
        public string Mode 
        { 
            get { return mode; } 
            set 
            { 
                if (value == "fix" || value == "mobile") { mode = value; } 
                else
                {
                    Console.Write("modo incorrecto, ingrese un modo de estacionamiento valido (fix, mobile): ");
                    Mode = Console.ReadLine();
                }
            } 
        }

        public vehicle()
        {
            Console.Write("Introduzca el nombre del propietario: ");
            owner = Console.ReadLine();
            Console.Write("Introduzca el dni del propietario: ");
            owner_dni = Console.ReadLine();
            Console.Write("Introduzca el tipo de vehiculo: ");
            type = Console.ReadLine();
            Console.Write("Introduzca la patente del vehiculo: ");
            patent = Console.ReadLine();
            Console.Write("Introduzca el modo de estacionamiento (fix, mobile): ");
            Mode = Console.ReadLine();
            Console.Write("Introduzca la hora de ingreso, formato ( hhmm ex: 1400 -> 2:00 pm ): ");
            in_time = Convert.ToInt32(Console.ReadLine());
        }

        public int partial_check(int time)
        {
            int pay = time;
            if (mode == "fix")
            {
                pay -= in_time;
                pay *= 2;
                pay += 500;
                return pay;
            }
            else
            {
                pay -= in_time;
                pay *= 2;
                return pay;
            }
        }

        public void checkout() 
        {
            Console.Write("Introduzca la hora de salida, formato ( hhmm ex: 1400 -> 2:00 pm ): ");
            out_time = Convert.ToInt32(Console.ReadLine());
            int pay = out_time;
            if (mode == "fix")
            {
                Console.WriteLine("type fix");
                pay -= in_time;
                pay *= 2;
                pay += 500;
                Console.WriteLine(pay);
                return;
            }
            else
            {
                Console.WriteLine("type mobile");
                pay -= in_time;
                pay *= 2;
                Console.WriteLine(pay);
                return;
            }
        }
    }
}
