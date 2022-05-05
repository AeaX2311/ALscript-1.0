using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALscript {
    class Program {
        static List<string> alfabetoMinuscula = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static List<string> alfabetoMayuscula = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        static List<string> alfabetoDigitos = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string alfabetoSimbolo = "_";

        static void Main(string[] args) {
            validarIdentificador();
            Console.ReadKey();
        }

        private static void validarIdentificador() {
            Console.WriteLine("ALscript - Identificadores váidos.\n");
            Console.WriteLine("¿Qué desea hacer?\n[0]-Determinar validez de identificador. \n[1]-Salir.");
            int auxiliar = int.Parse(Console.ReadLine());

            while(auxiliar != 1) {
                if(procesoValidarIdentificador()) {
                    Console.WriteLine("    Identificador válido.\n");
                } else {
                    Console.WriteLine("    Error de identificador: Favor de revisar que el identificador inicie con letra minuscula, y que contenga unicamente Mayusculas, Minusculas, numeros o guion bajo.\n");
                }

                Console.WriteLine("¿Qué desea hacer?\n[0]-Determinar validez de identificador. \n[1]-Salir.");
                auxiliar = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Fin.");
        }

        private static bool procesoValidarIdentificador() {
            Console.WriteLine("Identificador: ");
            string miVariable = Console.ReadLine();
            int length = miVariable.Length;

            for(int x = 0; x < length; x++) {
                string caracterActual = miVariable[x].ToString();

                if(x == 0) { //Estado 138
                    if(alfabetoMinuscula.Contains(caracterActual)) {
                        continue;
                    } else {
                        return false;
                    }
                } else if(alfabetoMinuscula.Contains(caracterActual) ||  //Estado 139
                        alfabetoMayuscula.Contains(caracterActual) ||
                        alfabetoDigitos.Contains(caracterActual) ||
                        alfabetoSimbolo == caracterActual) {
                    continue;
                } else {
                    return false;
                }
            }

            return true;
        }

    }
}
