using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using theDiary.Models;
using LauraJaChristianHarkka;






namespace theDiary
{
    class Program
    {

        static async Task Main(string[] args)
        { 
            while (true)
        {
                Console.WriteLine(@"  
           .od88888888bo.      
       .od8888888888888888bo.
   .od888888888888888888888888bo.
od88888888888888888888888888888888bo
 `~888888888888888888888888888888~'
    `~888888888888888888888888~'|
       `~888888888888888888~'   |
         |`~888888888888~'|     |
         \   `~888888~'   /    |||
          `-_   `~~'   _-'     ||| 
             `--____--'         |");

            //await MainMenu();
            
            Console.WriteLine("     Valikko");
            Console.WriteLine("     1) Tietojen kysely ja tallennus tietokantaan ");
            Console.WriteLine("     2) Otsikon ja Id:n haku tietokannasta ");
            Console.WriteLine("     3) ID:n poisto tietokannasta ");
            Console.WriteLine("     4) Otsikon päivitys tietokantaan ");
            Console.WriteLine("     5) Poistu ohjelmasta ");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 5)
                {
                    break;
                }

                switch (userChoice)
                {
                    case 1:
                        await Tallennus(TietojenKysely());
                        Console.WriteLine("     Tiedot tallennettiin onnistuneesti.");
                        Console.WriteLine("     Palaa Menuun painamalla mitä tahansa näppäintä.");
                        Console.ReadKey();
                        break;

                    case 2:
                        await SearchTitleAndId();
                        Console.WriteLine("     Palaa Menuun painamalla mitä tahansa näppäintä.");
                        Console.ReadKey();
                        break;

                    case 3:
                        await DeleteID();
                        Console.WriteLine("     Palaa Menuun painamalla mitä tahansa näppäintä.");
                        Console.ReadKey();
                        break;
                    case 4:
                        UpdateTitle();
                        Console.WriteLine("     Palaa Menuun painamalla mitä tahansa näppäintä.");
                        Console.ReadKey();
                        break;
                }


       /* var topic = TietojenKysely();

        await Tallennus(topic);
        await SearchTitleAndId();
        await DeleteID();
        UpdateTitle();*/

    }


}
           

            public static Topic TietojenKysely()

        {
            Topic topic = new Topic();

            Console.WriteLine("Syötä otsikko: ");
            topic.Title = Console.ReadLine();

            Console.WriteLine("Aiheen kuvaus: ");
            topic.Description = Console.ReadLine();

            Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
            topic.Source = Console.ReadLine();

            topic.StartLearningDate = new DateTime(2020, 12, 24);
            Console.WriteLine("Aloituspäivä: " + topic.StartLearningDate.ToShortDateString());

            Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa n/y");
            string InProgress = Console.ReadLine();

            if (InProgress == "y")
            {
                topic.InProgress = true;
                Console.WriteLine("Tsemppiä!");

            }
            else if (InProgress == "n")
            {
                topic.InProgress = false;
                Console.WriteLine("Koska aiheen opiskelu päättyi? - Syötä muodossa xx/xx/xxxx ");
                topic.CompletionDate = Convert.ToDateTime(Console.ReadLine());

                if (topic.CompletionDate != null)
          
                {
                    DateTime apumuuutaja = topic.CompletionDate ?? DateTime.Now;
                    topic.TimeSpent = Convert.ToInt32(Class1.timeSpent(topic.StartLearningDate, apumuuutaja));
                }

            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
                    topic.TimeToMaster = int.Parse(Console.ReadLine());
                    break;
                }


                catch
                {
                    Console.WriteLine("Error! Yritä uudelleen kirjoittamalla kokonaislukuja.");
                }

            }
            return topic;

        }

       public static async Task Tallennus(Topic topic)
        {
            using (theDiaryContext testiYhteys = new theDiaryContext())
            {
                Topic uusi = new Topic()
                {
                    //Id = topic.Id,
                    Title = topic.Title,
                    Description = topic.Description,
                    TimeToMaster = Convert.ToInt32(topic.TimeToMaster),
                    TimeSpent = Convert.ToInt32(topic.TimeSpent),
                    Source = topic.Source,
                    StartLearningDate = topic.StartLearningDate,
                    InProgress = topic.InProgress,
                    CompletionDate = topic.CompletionDate


                };
                await Task.Run(()=>testiYhteys.Topics.Add(uusi));
                testiYhteys.SaveChanges();

            }
 
        }

        public static async Task SearchTitleAndId()
        {
            using (theDiaryContext testiYhteys = new theDiaryContext())
            {
                Console.WriteLine("Anna haettava otsikko: ");
                string testihaku = Console.ReadLine();
                var hakukannasta = testiYhteys.Topics.Select(topic => topic);
              
                //hakukannasta = hakukannasta.Where(otsikko => otsikko.Title == testihaku);
                IEnumerable<Topic> hakuKannastaKaksi = await Task.Run(()=>testiYhteys.Topics.Where(otsikko => otsikko.Title == testihaku));
                //jos haettaisiin kaikki otsikot tietokannasta, select Wheren tilalle ja otsikko => otsikko)

                try
                {
                    foreach (var haetaanvaan in hakuKannastaKaksi)
                    {
                        Console.WriteLine("Hakemallasi otsikolla löytyi ID: " + haetaanvaan.Id + " Otsikko: " + haetaanvaan.Title);

                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                var viimeisin = testiYhteys.Topics.Max(topikki => topikki.Id);

                Console.WriteLine("Viimeisin Id on: " + viimeisin);

            }

        }

        public static async Task DeleteID()
        {
            using (theDiaryContext testiYhteys = new theDiaryContext())
            {
                Console.WriteLine("Hae Id: ");
                int sSearch = int.Parse(Console.ReadLine());
                var haku = await Task.Run(()=>testiYhteys.Topics.Where(x => x.Id == sSearch).Single());
                //haku.Id = topic.Id;
                testiYhteys.SaveChanges();

                if (sSearch == haku.Id)
                {
                    Console.WriteLine(sSearch + " Löytyi.");
                    Console.WriteLine("olet onnen Pekka!");
                }
                else
                {
                    Console.WriteLine("Id:tä ei löydy.");
                }

                Console.WriteLine("Haluatko poistaa haetun ID:n? y/n? ");
                var poistaOtsikko = Console.ReadLine();

                if (poistaOtsikko == "y")
                {
                    //tList.RemoveAll(x => x.Id == poistaId);
                    testiYhteys.Topics.Remove(haku);
                    testiYhteys.SaveChanges();
                }

                if (poistaOtsikko == "n")
                {
                    Console.WriteLine("ID:tä ei poistettu.");
                    Console.WriteLine("Hienosti menee.");
                }

            }
        }

           public static void UpdateTitle()
            {
                using (theDiaryContext testiYhteys = new theDiaryContext())

                {
                    Console.WriteLine("Haluatko päivittää otsikon? n/y: ");
                    var paivitaOtsikko = Console.ReadLine();

                    if (paivitaOtsikko == "y")
                    {
                            Console.WriteLine("Minkä Id:n otsikon haluat päivittää?");
                            int updateID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Anna uusi otsikko: ");
                            string uusiOtsikko = Console.ReadLine();
                            Console.WriteLine("Uusi otsikko on: " + uusiOtsikko);

                            var muutos = testiYhteys.Topics.Where(x => x.Id == updateID).Single();
                            muutos.Title = uusiOtsikko;
                            testiYhteys.SaveChanges();
                    }
                    else if (paivitaOtsikko == "n")
                    {
                        Console.WriteLine("Kiitos tiedoista.");

                    }
             

                }

                

                }
            }
            }
        


    
