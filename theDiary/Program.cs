using System;
using System.Collections.Generic;

namespace theDiary
{
    class Program
    {
        static void Main(string[] args)
        {


          
            Topic tunniste = new Topic();
            {
                Console.WriteLine("Syötä tunniste: ");
                tunniste.tunniste = int.Parse(Console.ReadLine());
               //testataan uudestaan
                
            }

            Topic title = new Topic();
            {
                Console.WriteLine("Aiheen otsikko: ");
                myTopic = Console.ReadLine();
 
            }

            Topic description = new Topic();
            {
                Console.WriteLine("Aiheen kuvaus: ");
                Console.ReadLine();

            }

            Topic EstimatedTimeToMaster = new Topic();
            {
                Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
                Console.ReadLine();
            }

            Topic TimeSpent = new Topic();

            {
                Console.WriteLine("Kauan käytit aikaa?: ");
                Console.ReadLine();

            }

            Topic Source = new Topic();
            {
                Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
                Console.ReadLine();

            }

            Topic StartLearningDate = new Topic();
            {
                Console.WriteLine("Datetime - aloitusaika: ");
                Console.ReadLine();
            }


            Topic InProgress = new Topic();
         
            {
                Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa kyllä/ei");
                Console.ReadLine();
            }

            Topic CompletionDate = new Topic();
            {
                Console.WriteLine("Koska aiheen opiskelu päättyy? ");
                Console.ReadLine();
            }
            
           
        }

        class Topic
        {


           // private static List<Topic> topics = new List<Topic>();

            public int tunniste { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public double EstimatedTimeToMaster { get; set; }
            public double TimeSpent { get; set; }
            public string source { get; set; }
            public DateTime StartLearningDate { get; set; }
            public bool InProgress { get; set; }
            public DateTime CompletionDate {get; set;}

            public Topic (int aTunniste)
            {
                tunniste = aTunniste;
            }

        }

    }
}
