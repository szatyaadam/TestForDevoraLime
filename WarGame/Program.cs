using System;


namespace WarGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Soldier Arrow = new Soldier( "Arrow", 100) ;
            Soldier HorseRider = new Soldier("HorseRider", 150) ;
            Soldier Swordsman  = new Soldier("Swordsman", 120) ;

            Console.WriteLine("Give the numbers of the soldiers :");

            #region Data request and validation
            int Soldiers;
            String x =Console.ReadLine();
        
            while (!Int32.TryParse(x, out Soldiers) ||Convert.ToInt32(x)<=1)
            {
               try
                {
                   if ( Convert.ToInt32(x) <= 1)
                    {
                        Console.WriteLine("The minimum numbers of the soldiers is : 2");
                    }
                }
                catch
                {
                Console.WriteLine("Not a valid number, try again.");
                }
                x =Console.ReadLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
