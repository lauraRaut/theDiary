﻿using System;


namespace theDiary
{
    class Program
    {
        static void Main(string[] args)
        {



            Topic tunniste = new Topic();
            {
                Console.WriteLine("Syötä tunniste: ");
                int id = int.Parse(Console.ReadLine());


            }

            Topic title = new Topic();
            {
                Console.WriteLine("Aiheen otsikko: ");
                string otsikko = Console.ReadLine();

            }

            Topic description = new Topic();
            {
                Console.WriteLine("Aiheen kuvaus: ");
                string kuvaus = Console.ReadLine();

            }

            Topic EstimatedTimeToMaster = new Topic();
            {
                Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
                int arvioituAika = int.Parse(Console.ReadLine());
            }

            Topic TimeSpent = new Topic();

            {
                Console.WriteLine("Kauan käytit aikaa?: ");
                int kaytettyAika = int.Parse(Console.ReadLine());

            }

            Topic Source = new Topic();
            {
                Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
                string lahde = Console.ReadLine();

            }

            Topic StartLearningDate = new Topic();
            {
                Console.WriteLine("Datetime - aloitusaika - syötä muodossa xx,xx,xxxx ");
                DateTime aloitus = Convert.ToDateTime(Console.ReadLine());
            }


            Topic InProgress = new Topic();

            {
                Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa N/Y");
                var kesken = Console.ReadLine();
                if (valinta == "N")
                {
                    kesken.InProgress = false;



                }

                Topic CompletionDate = new Topic();
                {
                    Console.WriteLine("Koska aiheen opiskelu päättyy? - Syötä muodossa xx.xx.xxxx ");
                    DateTime paatos = Convert.ToDateTime(Console.ReadLine());
                }


            }
        }

        class Topic
        {

            public int tunniste { get; set; }
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
