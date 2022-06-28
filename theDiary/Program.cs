using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using theDiary.Models;
using LauraJaChristianHarkka;





//Päivitän tämän sekametelin ensi viikolla Checkpointia tehdessä opittujen taitojen tasolle :) 
//- Laura
namespace theDiary
{
    class Program
    {
        // private static string topic;

        static void Main(string[] args)
        {

            Class1 oliomme = new Class1();
            

            String polku = @"C:\Users\laura\source\repos\theDiary\theDiary\theDiaryReadline.txt";



            int sSearch;


            List<Topic> tList = new List<Topic>();


            Topic topic = new Topic();


            /*Console.WriteLine("Syötä id: ");
            topic.Id = int.Parse(Console.ReadLine());*/



            Console.WriteLine("Aiheen otsikko: ");
            topic.title = Console.ReadLine();

            Console.WriteLine("Aiheen kuvaus: ");
            topic.description = Console.ReadLine();

            Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
            topic.EstimatedTimeToMaster = int.Parse(Console.ReadLine());

            Console.WriteLine("Kauan käytit aikaa?: ");
            topic.TimeSpent = double.Parse(Console.ReadLine());

            Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
            topic.source = Console.ReadLine();

            topic.StartLearningDate = new DateTime(2020, 12, 24);
            Console.WriteLine("Aloituspäivä: " + topic.StartLearningDate.ToShortDateString());
            bool result = oliomme.IsFuture(topic.StartLearningDate);
            Console.WriteLine(result);

            Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa n/y");
            string InProgress = Console.ReadLine();

            //clear tekstin tyhjentämään


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
                TimeSpan opiskeltuAika = topic.CompletionDate - topic.StartLearningDate;
                Console.WriteLine("Käytit opiskeluun aikaa: " + opiskeltuAika.TotalDays + " päivää");

            }




            if (File.Exists(polku))
            {

                File.AppendAllText(polku, Convert.ToString(topic.Id + topic.title + topic.description + topic.EstimatedTimeToMaster + topic.TimeSpent + topic.source + topic.StartLearningDate + topic.InProgress + topic.CompletionDate) + Environment.NewLine);


                {
                    Console.WriteLine("Haluatko tulostaa id-listan, n/y: ");
                    var answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        Console.WriteLine(topic.Id + "\n" + topic.title + "\n" + topic.description + "\n" + topic.EstimatedTimeToMaster + "\n" + topic.TimeSpent + "\n" + topic.source + "\n" + topic.StartLearningDate.ToShortDateString() + "\n" + topic.InProgress + "\n" + topic.CompletionDate.ToShortDateString());
                        //Console.WriteLine(File.ReadAllText(polku));


                        //File.ReadAllTtext kehityksessä niin, että tulostaa vain tämän kierroksen. 

                    }
                    else if (answer == "n")
                    {
                        Console.WriteLine("Kiitos tiedoista.");

                    }
                }

            }
            else
            {
                Console.WriteLine("Tiedostoa ei löydy");
            }

            tList.Add(topic);






           


            using (theDiaryContext testiYhteys = new theDiaryContext())
            {
                var taulu = testiYhteys.Topics.Select(topikki => topikki);
                Models.Topic uusi = new Models.Topic()
                {
                    //Id = topic.Id,
                    Title = topic.title,
                    Description = topic.description,
                    TimeToMaster = Convert.ToInt32(topic.EstimatedTimeToMaster),
                    TimeSpent = Convert.ToInt32(topic.TimeSpent),
                    Source = topic.source,
                    StartLearningDate = topic.StartLearningDate,
                    InProgress = topic.InProgress,
                    CompletionDate = topic.CompletionDate


                };
                testiYhteys.Topics.Add(uusi);
                testiYhteys.SaveChanges();

                /* taulu = testiYhteys.Topics.Select(topikki => topikki);
                 foreach (var rivi in taulu)
                 {
                     Console.WriteLine(rivi.Description);
                 }*/


               

                Console.WriteLine("Anna otsikko: ");
                string testihaku = Console.ReadLine();
                var hakukannasta = testiYhteys.Topics.Where(otsikko => otsikko.Title == testihaku);
                //jos haettaisiin kaikki otsikot tietokannasta, select Wheren tilalle ja otsikko => otsikko)

                foreach(var haetaanvaan in hakukannasta)
                {
                    Console.WriteLine(haetaanvaan.Title);
                }
                testiYhteys.SaveChanges();


                var viimeisin = testiYhteys.Topics.Max(topikki => topikki.Id);

                Console.WriteLine("Viimeisin Id on: " + viimeisin);
                //jos haluaisi lisätä yhden lisää juoksevasti koodissa
                //GlobalID = viimeisin++;

                Console.WriteLine("Hae Id: ");
                sSearch = int.Parse(Console.ReadLine());
                var haku = testiYhteys.Topics.Where(x => x.Id == sSearch).Single();
                // haku.Id = topic.Id;
                // testiYhteys.SaveChanges();

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


                /*Topic oFound = tList.Find(oTop => oTop.Id.Equals(sSearch));

                if (oFound != null)
                {
                    Console.WriteLine("Id löytyi!");
                }
                else
                {
                    Console.WriteLine("Id ei löytynyt");
                }

                Topic otsikko = tList.Find(oTit => oTit.title.Equals(otsikonHaku));

                if (otsikko != null)
                {
                    Console.WriteLine("Otsikko löytyi!");
                }
                else
                {
                    Console.WriteLine("Otikkoa ei löytynyt");
                }*/



                Console.WriteLine("Haluatko päivittää otsikon? n/y: ");
                var paivitaOtsikko = Console.ReadLine();

                if (paivitaOtsikko == "y")
                {
                    foreach (var aOtsikko in tList.Select(a => a.title))
                    {
                        Console.WriteLine("Minkä Id:n otsikon haluat päivittää?");
                        int updateID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Anna uusi otsikko: ");
                        topic.title = Console.ReadLine();
                        Console.WriteLine("Uusi otsikko on: " + topic.title);

                        var muutos = testiYhteys.Topics.Where(x => x.Id == updateID).Single();
                        muutos.Title = topic.title;
                        testiYhteys.SaveChanges();
                    }
                }
                else if (paivitaOtsikko == "n")
                {
                    Console.WriteLine("Kiitos tiedoista.");

                }





            }
        }
        //WANHAA

        /* Console.WriteLine("Haluatko päivittää Id:n? n/y: ");
           var paivitaID = Console.ReadLine();

           if (paivitaID == "y")
           {
               foreach (var aId in tList.Select(a => a.Id))
               {
                   Console.WriteLine("Anna uusi ID: ");
                   topic.Id = int.Parse(Console.ReadLine());
                   Console.WriteLine("Uusi ID on: " + topic.Id);

               }

           }
           else if (paivitaID == "n")
           {
               Console.WriteLine("Kiitos tiedoista.");

           }*/

        /*Topic oFound = tList.Find(oTop => oTop.Id.Equals(sSearch));

            if (oFound != null)
            {
                Console.WriteLine("Id löytyi!");
            }
            else
            {
                Console.WriteLine("Id ei löytynyt");
            }

            Topic otsikko = tList.Find(oTit => oTit.title.Equals(otsikonHaku));

            if (otsikko != null)
            {
                Console.WriteLine("Otsikko löytyi!");
            }
            else
            {
                Console.WriteLine("Otikkoa ei löytynyt");
            }*/
        /*Console.WriteLine("Haluatko poistaa ID:n? y/n? ");
         var poistaId = Console.ReadLine();

         if (poistaId == "y")
         {
             //tList.RemoveAll(x => x.Id == poistaId);
             Console.WriteLine("Anna poistettava ID-numero: ");
             int chunkID = int.Parse(Console.ReadLine());
             tList.RemoveAll(x => x.Id == chunkID);
             Console.WriteLine(chunkID + " on nyt poistettu");


         }


         else
         {
             Console.WriteLine("Id säilytettiin.");
         }
     }*/

       /* Console.WriteLine("Haluatko poistaa otsikon? y/n? ");
            var poistaOtsikko = Console.ReadLine();

            if (poistaOtsikko == "y")
            {
                //tList.RemoveAll(x => x.Id == poistaId);
                Console.WriteLine("Anna poistettava otsikko: ");
                string chunkTitle = Console.ReadLine();
        tList.RemoveAll(x => x.title == chunkTitle);
                Console.WriteLine(chunkTitle + " on nyt poistettu");
            }

            else
            {
                Console.WriteLine("Otsikko säilytettiin.");
            }


Console.WriteLine(File.ReadAllText(polku));
       */

class Topic
        {

            public int Id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public double EstimatedTimeToMaster { get; set; }
            public double TimeSpent { get; set; }
            public string source { get; set; }
            public DateTime StartLearningDate { get; set; }
            public bool InProgress { get; set; }
            public DateTime CompletionDate { get; set; }



        }

    }
}
