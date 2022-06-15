﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



//Päivitän tämän sekametelin ensi viikolla Checkpointia tehdessä opittujen taitojen tasolle :) 
//- Laura
namespace theDiary
{
    class Program
    {
        // private static string topic;

        static void Main(string[] args)
        {
            String polku = @"C:\Users\laura\source\repos\theDiary\theDiary\theDiaryReadline.txt";


            int sSearch;
            string otsikonHaku;

            List<Topic> tList = new List<Topic>();


            Topic topic = new Topic();

            
            Console.WriteLine("Syötä tunniste: ");
            topic.Id = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Aiheen otsikko: ");
            topic.title = Console.ReadLine();

            Console.WriteLine("Aiheen kuvaus: ");
            topic.description = Console.ReadLine();

            Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
            topic.EstimatedTimeToMaster = int.Parse(Console.ReadLine());

            Console.WriteLine("Kauan käytit aikaa?: ");
            topic.TimeSpent = int.Parse(Console.ReadLine());

            Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
            topic.source = Console.ReadLine();

            topic.StartLearningDate = new DateTime(2020, 12, 24);
            Console.WriteLine("Aloituspäivä: " + topic.StartLearningDate);

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


            Console.WriteLine("Hae Id: ");
            sSearch = int.Parse(Console.ReadLine());

            Console.WriteLine("Hae otsikko: ");
            otsikonHaku = Console.ReadLine();

           
            Topic oFound = tList.Find(oTop => oTop.Id.Equals(sSearch));

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
            }

            Console.WriteLine("Haluatko päivittää Id:n? n/y: ");
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

            }



        }
    

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
