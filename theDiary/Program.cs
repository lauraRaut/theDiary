using System;
using System.Collections.Generic;

namespace diaryn_siivous
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Topic> tList = new List<Topic>();

            Topic kysymykset = TietojenKysely();

            tList.Add(TietojenKysely());

        }


        static async Task UserInputs()
        {

            /*Class1 compare = new Class1();
            bool newTopic = true;*/
       
        
            using (theDiaryContext testiYhteys = new theDiaryContext())
            {
                var taulu = testiYhteys.Topics.Select(topikki => topikki);
                Topic topic = new Topic()
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

            }
}

        public static Topic TietojenKysely()
        {
            Topic topic = new Topic();

            Console.WriteLine("Syötä Id: ");
            topic.title = Console.ReadLine();

            Console.WriteLine("Aiheen kuvaus: ");
            topic.description = Console.ReadLine();

            Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
            topic.source = Console.ReadLine();

            topic.StartLearningDate = new DateTime(2020, 12, 24);
            Console.WriteLine("Aloituspäivä: " + topic.StartLearningDate.ToShortDateString());
            bool result = oliomme.IsFuture(topic.StartLearningDate);
            Console.WriteLine(result);

            Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa n/y");
            bool InProgress = Convert.ToBoolean(Console.ReadLine());

            if (InProgress == true)
            {

                Console.WriteLine("Tsemppiä!");

            }
            else if (InProgress == false)
            {
                topic.Inprogress = false;
                Console.WriteLine("Koska aiheen opiskelu päättyi? - Syötä muodossa xx/xx/xxxx ");
                topic.CompletionDate = Convert.ToDateTime(Console.ReadLine());

            }

           // double EstimatedTimeToMaster;

            while (true)
            {
                try
                {
                    Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
                    topic.EstimatedTimeToMaster = int.Parse(Console.ReadLine());
                    break;
                }


                catch
                {
                    Console.WriteLine("Error! Yritä uudelleen kirjoittamalla kokonaislukuja.");
                }

            }

            


        }




        public class Topic
        {
            public int Id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public double EstimatedTimeToMaster { get; set; }
            public double TimeSpent { get; set; }
            public string source { get; set; }
            public DateTime StartLearningDate { get; set; }
            public bool Inprogress { get; set; }
            public DateTime CompletionDate { get; set; }

           
        }

        }

    }
