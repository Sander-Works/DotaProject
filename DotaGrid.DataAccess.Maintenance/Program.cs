using DotaGrid.model;
using System;
using Microsoft.EntityFrameworkCore;



namespace DotaGrid.DataAccess.Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = @"Server=(localdb)\MSSQLLocalDB;Database=sjriis;Trusted_Connection=True;ConnectRetryCount=0";
            var optionsBuilder = new DbContextOptionsBuilder<HeroContext>();
            optionsBuilder.UseSqlServer(connection);


            Console.WriteLine("Enter hero name: ");
            string inputHeroName = Console.ReadLine();
            Console.WriteLine("Enter the heroes HP: ");
            int inputHp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the heroes mana: ");
            int inputMana = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the heroes Q : ");
            string q = Console.ReadLine();
            Console.WriteLine("Enter the heroes W: ");
            string w = Console.ReadLine();
            Console.WriteLine("Enter the heroes E: ");
            string e = Console.ReadLine();
            Console.WriteLine("Enter the heroes Ultimate: ");
            string ultimate = Console.ReadLine();
            Console.WriteLine("Choose mainattribute: agility, strength or intelligence");
            Mainattribute mainattribute = new Mainattribute { MainAttributeType = Console.ReadLine() };
            Console.WriteLine("Enter playstyle: ");
            string playstyle = Console.ReadLine();
            Console.WriteLine("Enter the heroes movementspeed: ");
            int inputMs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the heroes armor: ");
            int inputArmor = Convert.ToInt32(Console.ReadLine());


            CreateObjects(inputHeroName, inputHp, inputMana, q, w, e, ultimate, playstyle, mainattribute, inputMs, inputArmor, optionsBuilder);
            QueryData(optionsBuilder);
        }

        private static void CreateObjects(string inputHeroName, int inputHp, int inputMana, string q, string w, string e,
          string playstyle, string ultimate, Mainattribute mainattribute, int inputMs, int inputArmor, DbContextOptionsBuilder<HeroContext> optionsBuilder)
        {
            using (var db = new HeroContext(optionsBuilder.Options))
            {
                Hero newHero = new Hero()
                {
                    Name = inputHeroName,
                    Hp = inputHp,
                    Mana = inputMana,
                    Q = q,
                    W = w,
                    E = e,
                    Ultimate = ultimate,
                    Playstyle = playstyle,
                    Mainattribute = mainattribute,
                    Ms = inputMs,
                    Armor = inputArmor
                };
                db.Heroes.Add(newHero);
                db.SaveChanges();
            }
        }
        private static void QueryData(DbContextOptionsBuilder<HeroContext> optionsBuilder)
        {
            using (var db = new HeroContext(optionsBuilder.Options))
            {
                var heroes = db.Heroes;

                Console.WriteLine("\n");
                foreach (var hero in heroes)
                {
                    Console.WriteLine("{0}", hero.Name);

                }
            }

        }
    }
}
