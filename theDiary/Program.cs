using System;
using System.IO;

namespace theDiary
{
    class Program
    {
      // private static string topic;

        static void Main(string[] args)
        {
            String polku = @"C:\Users\laura\source\repos\theDiary\theDiary\theDiaryReadline.txt";

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


            // Muista tulostaa myös käytetty aika


            /* Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa N/Y");
             topic.InProgress = Convert.ToBoolean(Console.ReadLine());

         if (topic.InProgressInProgress == "N")
         {
             topic.InProgress = false;

         }
         if (InProgress == "Y")
         {
             topic.InProgress = true;

         }*/

            if (File.Exists(polku))
            {

                File.AppendAllText(polku, Convert.ToString(topic.Id + topic.title + topic.description + topic.EstimatedTimeToMaster + topic.TimeSpent + topic.source + topic.StartLearningDate + topic.InProgress + topic.CompletionDate) + Environment.NewLine);

               /* try
                {
                    String[] lines;
                    lines = File.ReadAllLines(polku);

                    for (int i = 0; i < lines.Length; i++) */
                    {
                        Console.WriteLine("Haluatko tulostaa id-listan, n/y: ");
                        var answer = Console.ReadLine();

                        if (answer == "y")
                        {
                        Console.WriteLine(topic.Id + "\n" + topic.title + "\n" + topic.description + "\n"  + topic.EstimatedTimeToMaster + "\n" + topic.TimeSpent + "\n" + topic.source + "\n" + topic.StartLearningDate.ToShortDateString() + "\n" + topic.InProgress + "\n" + topic.CompletionDate.ToShortDateString()); 
                            
                            
                       
                        }
                        else if (answer == "n")
                                {
                            Console.WriteLine("Kiitos tiedoista.");
                            
                        }
                    }
               /* }

                catch(Exception e)
                {
                    Console.WriteLine("Tiedostoa ei voida lukea.");
                    Console.WriteLine(e.Message); */
                
            }
            else
            {
                Console.WriteLine("Tiedostoa ei löydy");
            }

            Console.ReadKey();
           
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
