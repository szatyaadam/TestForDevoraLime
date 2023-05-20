using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using WarGame.Models;
namespace WarGame
{
    public class Program
    {
        #region Random soldiers to the battleField
        public static List<Army> RandomGeneration(int numberOfSoldiers)
        {
            List<string> Soldiers = new List<string> { "Arrow", "HorseRider", "Swordsman" };
            var random = new Random();
            List<Army> battleField = new List<Army>();
            for (int i = 0; i < numberOfSoldiers; i++)
            {
                var hero = Soldiers[random.Next(Soldiers.Count)];

                switch (hero)
                {
                    case "Arrow":
                        Soldier Arrow = new Soldier(hero, 100,100);
                        Army Arrows = new Army(battleField.Count + 1, Arrow);
                        battleField.Add(Arrows);
                        break;
                    case "HorseRider":
                        Soldier HorseRider = new Soldier(hero, 150,150);
                        Army HorseRiders = new Army(battleField.Count + 1, HorseRider);
                        battleField.Add(HorseRiders);
                        break;
                    case "Swordsman":
                        Soldier Swordsman = new Soldier(hero, 120, 120);
                        Army Swordsmans = new Army(battleField.Count + 1, Swordsman);
                        battleField.Add(Swordsmans);
                        break;
                }
            }
            return battleField;
        }
        #endregion
        #region LifeIncrease 
        public static void Increise(Army entity)
        {
            if (entity.Soldier.lifePower < entity.Soldier.MaxLifePower)
            {
                entity.Soldier.lifePower += 10;
                if (entity.Soldier.lifePower >entity.Soldier.MaxLifePower) entity.Soldier.lifePower =entity.Soldier.MaxLifePower;
            }
        }
        public static void LifeIncrease(List<Army> healler, List<Army> battleers)
        {
            var toHeal = healler.Where(x => x.Id != battleers.ElementAt(0).Id && x.Id != battleers.ElementAt(1).Id).ToList();
            for (int i = 0; i < toHeal.Count; i++)
            {
                switch (toHeal[i].Soldier.name)
                {
                    case "Arrow":
                        Increise(toHeal[i]);
                        break;
                    case "HorseRider":
                        Increise(toHeal[i]);
                        break;
                    case "Swordsman":
                        Increise(toHeal[i]);
                        break;
                }

            }
        }
        #endregion
        #region Battle
        public static void LifePowerCheck(Soldier defender, Soldier invader)
        {
            if ((invader.MaxLifePower * 0.15) > (invader.lifePower / 2)) invader.lifePower = 0;
            else invader.lifePower = invader.lifePower / 2;

            if ((defender.MaxLifePower * 0.15) > (defender.lifePower / 2)) defender.lifePower = 0;
            else defender.lifePower = defender.lifePower / 2;
        }

        public static List<Army> Battle(Army defender, Army invader, List<Army> soldiers)
        {
            switch (invader.Soldier.name)
            {
                case "Arrow":
                    switch (defender.Soldier.name)
                    {
                        case "Arrow":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);
                            break;
                        case "HorseRider":
                            defender.Soldier.lifePower = defender.Soldier.lifePower * 0.6;
                            if ((invader.Soldier.lifePower * 0.15) > (invader.Soldier.lifePower / 2)) invader.Soldier.lifePower = 0;
                            else invader.Soldier.lifePower = invader.Soldier.lifePower / 2;
                            break;
                        case "Swordsman":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);
                            break;
                    }
                    break;
                case "HorseRider":
                    switch (defender.Soldier.name)
                    {
                        case "Arrow":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);
                            break;
                        case "HorseRider":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);
                            break;
                        case "Swordsman":
                            invader.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);
                            break;
                    }
                    break;
                case "Swordsman":
                    switch (defender.Soldier.name)
                    {
                        case "Arrow":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);

                            break;
                        case "HorseRider":
                            LifePowerCheck(defender.Soldier, invader.Soldier);

                            break;
                        case "Swordsman":
                            defender.Soldier.lifePower = 0;
                            LifePowerCheck(defender.Soldier, invader.Soldier);

                            break;
                    }
                    break;
            }

            //reduce the warriors after the battle


            Console.WriteLine($"\t{invader.Id}.{invader.Soldier.name} LifePower={invader.Soldier.lifePower}" +
                              $"\n\t{defender.Id}.{defender.Soldier.name} LifePower={defender.Soldier.lifePower}");
            for (int i = 0; i < soldiers.Count; i++)
            {
                if (soldiers.ElementAt(i).Soldier.lifePower <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t{soldiers.ElementAt(i).Id}.{soldiers.ElementAt(i).Soldier.name} Died");
                    Console.ResetColor();
                    soldiers.Remove(soldiers.ElementAt(i));
                }
              //  if (soldiers.Count < 1) break;
            }
            return soldiers;
        }
        #endregion
        static void Main(string[] args)
        {
            var random = new Random();
            #region Data request and validation
            Console.WriteLine("Give the numbers of the soldiers :");
            int SoldierNum;
            String x = Console.ReadLine();

            while (!Int32.TryParse(x, out SoldierNum) || Convert.ToInt32(x) <= 1)
            {
                try
                {
                    if (Convert.ToInt32(x) <= 1)
                    {
                        Console.WriteLine("The minimum numbers of the soldiers is : 2");
                    }
                }
                catch
                {
                    Console.WriteLine("Not a valid number, try again.");
                }
                x = Console.ReadLine();
            }
            #endregion
            //Start the battle 
            try
            {
                var battleField = RandomGeneration(SoldierNum);
                while (battleField.Count > 1)
                {
                    //Choose the battle pairs 
                    List<Army> battleEntities = new List<Army>();
                    battleEntities.Add(battleField[random.Next(battleField.Count)]);
                    //if the random pairs is the same players
                    while (battleEntities.Count < 2)
                    {
                        if (battleEntities.Count < 2)
                        {
                            battleEntities.Add(battleField[random.Next(battleField.Count)]);
                        }
                        if (battleEntities[0].Id == battleEntities[1].Id)
                        {
                            battleEntities.Remove(battleEntities[1]);
                        }
                    }

                    //statement

                    Console.WriteLine($"{battleEntities[1].Id}.{battleEntities[1].Soldier.name}({battleEntities[1].Soldier.lifePower})" +
                                      $" Attacked {battleEntities[0].Id}.{battleEntities[0].Soldier.name}({battleEntities[0].Soldier.lifePower})");
                    LifeIncrease(battleField, battleEntities);
                    Battle(battleEntities[0], battleEntities[1], battleField);
                    System.Threading.Thread.Sleep(1000);
                }
                //End of the battle
                if (battleField.Count == 0)
                {
                    Console.WriteLine($"Nobody stay alived");
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(battleField[0].Id +". "+battleField[0].Soldier.name + " Won the battle.");
                Console.ResetColor();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
