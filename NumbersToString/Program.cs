using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToString
{
    class Program
    {
        private enum number { unit, dozen, hundred};
        private string[] units;
        private string[] ends;
        private bool test = false;
       
        Program()
        {
            units = new string[] { "zero", "jeden", "dwa", "trzy", "cztery", "piec", "szesc", "siedem", "osiem", "dziewiec"};
            ends = new string[] { "nascie", "dziescia", "dziesci", "dziesiat", "sta", "set" };
        }

        private string ConvertNumberToString(int[] testNumber)
        {
            string result = "";
            for (int i = 0; i < testNumber.Length; i++)
            {
                result += _ConvertNumberToString(testNumber[i], (number)(testNumber.Length - i - 1)) + " ";
            }
            return result;
        }
        private string _ConvertNumberToString (int number, number nr)
        {
            string tempData = units[number];
            switch (nr)
            {
                case Program.number.unit:
                    if (test)
                    {
                        tempData += ends[0];
                        test = false;
                    }                  
                    break;
                
                case Program.number.dozen:
                    {
                        switch (number)
                        {
                            case 1:     test = true; tempData = ""; break; 
                            case 2:     tempData += ends[1]; break;
                            case 3: 
                            case 4:     tempData += ends[2]; break;
                            default:    tempData += ends[3]; break;
                        }
                        break;
                    }
                case Program.number.hundred:
                    {
                        switch (number)
                        {
                            case 1:     tempData = "sto"; break;
                            case 2:     tempData = "dwiescie"; break;
                            case 3:
                            case 4:     tempData += ends[4]; break;
                            default:    tempData += ends[5]; break;                      
                        }
                        break;
                    }
                default: break;
            }
            return tempData;
        }
        static void Main(string[] args)
        {
            Program testuje = new Program();
            do
            {
                Console.Write("Podaj liczbe w zakresie 0-999: ");
                string inputString = Console.ReadLine();

                int[] inputInt = inputString.Select(n => Convert.ToInt32(n) - '0').ToArray();
                
                Console.WriteLine();
                try { Console.WriteLine(testuje.ConvertNumberToString(inputInt)); }
                catch { Console.WriteLine("Czy Ty wiesz czym sie rożnią liczby od znaków?"); }
                Console.Write("Jeszcze raz?");
            } while ("t" == Console.ReadLine());
            
        }
    }
}
