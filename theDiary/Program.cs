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

       
                Console.WriteLine("Datetime - aloitusaika - syötä muodossa xx,xx,xxxx ");
                topic.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
            

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

           
            {
                Console.WriteLine("Koska aiheen opiskelu päättyy? - Syötä muodossa xx/xx/xxxx ");
                DateTime CompletionDate = Convert.ToDateTime(Console.ReadLine());
            }



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
                            Console.WriteLine(topic.Id + topic.title + topic.description + topic.EstimatedTimeToMaster + topic.TimeSpent + topic.source + topic.StartLearningDate + topic.InProgress + topic.CompletionDate);
                            
                       
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
