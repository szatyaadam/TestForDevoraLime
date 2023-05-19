using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WarGame
{

    public class Program
    {
    #region Random soldiers to the battleField
    public static List<Soldier> RandomGeneration(int numberOfSoldiers,List<Soldier> FromList )
    {
        var random = new Random();
        List<Soldier> battleField = new List<Soldier>();
        for (int i = 0; i < numberOfSoldiers; i++)
        {

            var person= FromList[random.Next(FromList.Count)];
                if (person.id==null)
                {
                person.id = battleField.Count + 1;
                }
            battleField.Add(person);
        }
        return battleField; 
    }
    #endregion
        static void Main(string[] args)
        {
            #region Create the soldiers
            Soldier Arrow = new Soldier(null, "Arrow", 100) ;
            Soldier HorseRider = new Soldier(null,"HorseRider", 150) ;
            Soldier Swordsman  = new Soldier(null,"Swordsman", 120) ;
            List<Soldier> Soldiers = new List<Soldier> { Arrow, HorseRider, Swordsman };
            #endregion

            #region Data request and validation
            Console.WriteLine("Give the numbers of the soldiers :");
            int SoldierNum;
            String x =Console.ReadLine();
        
            while (!Int32.TryParse(x, out SoldierNum) ||Convert.ToInt32(x)<=1)
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
            var battleField= RandomGeneration(SoldierNum, Soldiers);
            var battle = RandomGeneration(2, battleField);
            
           
            Console.ReadKey();
        }
    }
}
