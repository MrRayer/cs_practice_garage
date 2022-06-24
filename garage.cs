using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garage_cspractice
{
    internal static class garage
    {
        static List<vehicle> garage_list = new List<vehicle>();

        static public void Start()
        {
            Console.WriteLine("Escriba el numero de la accion a realizar");
            Console.Write("1 - Ingreso de vehiculo, 2 - Egreso de vehiculo, 3 - Realizar partial checkout, 4 - Salir: ");
            string answer = Console.ReadLine();
            answer_check(answer);
        }

        static private void answer_check(string answer)
        {
            switch (answer) 
            {
                case "1":
                    Console.WriteLine("1 selected");
                    garage_list.Add(new vehicle());
                    Console.WriteLine("Vehiculo ingresado");
                    Start();
                    break;
                case "2":
                    Console.WriteLine("2 selected");
                    Console.Write("Introduzca el dni del dueño del vehiculo egresante: ");
                    string dni = Console.ReadLine();
                    int index = Dni_check(dni);
                    if (index == -1) { Start(); };
                    Console.WriteLine($"Dueño {garage_list[index].owner} encontrado");
                    garage_list[index].checkout();
                    garage_list.RemoveAt(index);
                    Start();
                    break;
                case "3":
                    Console.WriteLine("3 selected");
                    Console.Write("Ingrese la hora a revizar: ");
                    int check_time = Convert.ToInt32(Console.ReadLine());
                    int check_ammount = 0;
                    int vehicle_count = 0;
                    foreach (vehicle x in garage_list)
                    {
                        check_ammount += x.partial_check(check_time);
                        vehicle_count++;
                    }
                    Console.WriteLine($"{vehicle_count} guardados en el garage");
                    Console.WriteLine($"{check_ammount}$ hasta ahora en vehiculos guardados");
                    Start();
                    break;
                case "4":
                    return;
                case "test":
                    Console.WriteLine("Vehiculos ingresados:");
                    foreach (vehicle x in garage_list)
                    {
                        Console.WriteLine(x.type);
                    }
                    Console.WriteLine("Fin de vehiculos ingresados.");
                    Start();
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta");
                    Start();
                    break;
            }
        }

        static private int Dni_check(string dni)
        {
            int counter = 0;
            foreach (vehicle x in garage_list)
            {
                if (x.owner_dni == dni)
                {
                    return counter;
                }
                else { counter++; }
            }
            Console.WriteLine("dni no encontrado en la lista de vehiculos");
            return -1;
        }
    }
}
