using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using theDiary.Models;
using LauraJaChristianHarkka;


// Kysy Heidiltä/Martilta: 
//  - Tarkastetaan, onko awaitit nyt oikein
//  - Tallennus tapahtuu, kun aiheen opiskelu ei ole kesken, siirtyy hakuun, haku ei toimi
//  - jos opiskelu on kesken, kaatuu arvioidun ajan syötön jälkeen eikä tiedot tallennu kantaan.
//  - deleteID toimi aiemmin testatessa, kun search ei toiminut. Martin vinkkaama ToList poistettu.
//  - Liittyykö luokkakirjastoon?

//  - Main menun while-loopin break.



namespace theDiary
{
    class Program
    {

        static async Task Main(string[] args)
        {

            await MainMenu();
            
            var topic = TietojenKysely();

            await Tallennus(topic);
            await SearchTitleAndId();
            await DeleteID();
            await UpdateTitle();

        }

        public static async Task<bool> MainMenu()

        {
            Console.WriteLine("     Tervetuloa Lauran oppimispäiväkirjaan.");
            Console.WriteLine("     Mitä haluat hakea?");

            Console.WriteLine("     1. Tietojen syöttö.");
            Console.WriteLine("     2. Otsikon haku tietokannasta. ");
            Console.WriteLine("     3. Id:n poisto tietokannasta. ");
            Console.WriteLine("     4. Otsikon päivitys. ");
            Console.WriteLine("     5. Exit. ");
         

            bool userInput = int.TryParse(Console.ReadLine(), out int userChoice);
            if(!userInput)
            {
                Console.WriteLine("     Syötä numero 1-5. ");
                return true;
            }

            else
            { 
                while (true)
                
                    {
                    switch (userChoice)
                    {
                        case 1:
                            {
                                TietojenKysely();
                                return true;
                            }

                        case 2:
                            {
                                await SearchTitleAndId();
                                return true;
                            }

                        case 3:
                            {
                                await DeleteID();
                                return true;
                            }

                        case 4:
                            {
                                await UpdateTitle();
                                return true;
                            }
                        case 5:
                            {
                                Console.WriteLine("     Kiitos käynnistä. ");
                                break;

                            }

                        default:
                            {
                                Console.WriteLine("     Syötä numero 1-5. ");
                                return false;
                            }
                    }
                }
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
                topic.TimeSpent = Convert.ToInt32(Class1.timeSpent(topic.StartLearningDate, topic.CompletionDate));

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
                var hakuKannastaKaksi = await Task.Run(()=>testiYhteys.Topics.Where(otsikko => otsikko.Title == testihaku));
                //jos haettaisiin kaikki otsikot tietokannasta, select Wheren tilalle ja otsikko => otsikko)

                foreach (var haetaanvaan in hakuKannastaKaksi)
                {
                    Console.WriteLine(haetaanvaan);
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
                    Console.WriteLine(haku.Id + " Löytyi.");
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

           public static async Task UpdateTitle()
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

                            var muutos = await Task.Run(()=>testiYhteys.Topics.Where(x => x.Id == updateID).Single());
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


    
