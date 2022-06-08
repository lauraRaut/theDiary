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
                string title = Console.ReadLine();
           
                Console.WriteLine("Aiheen kuvaus: ");
                string kuvaus = Console.ReadLine();

      
                Console.WriteLine("Kuinka kauan arvioit aikaa kuluvan tehtävään?: ");
                int arvioituAika = int.Parse(Console.ReadLine());
        

                Console.WriteLine("Kauan käytit aikaa?: ");
                int kaytettyAika = int.Parse(Console.ReadLine());

        
                Console.WriteLine("Mahdollinen lähde, esim. web url tai kirja");
                string lahde = Console.ReadLine();

       
                Console.WriteLine("Datetime - aloitusaika - syötä muodossa xx,xx,xxxx ");
                DateTime aloitus = Convert.ToDateTime(Console.ReadLine());
            

                Console.WriteLine("Onko aiheen opiskelu kesken? Vastaa N/Y");
                var kesken = Console.ReadLine();
            if (kesken == "N")
            {
                topic.InProgress = false;
            }
            if (kesken == "Y")
            {
                topic.InProgress = true;
            }


            Topic CompletionDate = new Topic();
            {
                Console.WriteLine("Koska aiheen opiskelu päättyy? - Syötä muodossa xx,xx,xxxx ");
                DateTime paatos = Convert.ToDateTime(Console.ReadLine());
            }

        

            if (File.Exists(polku))
            {

                File.AppendAllText(polku, Convert.ToString(topic.Id + topic.title + Environment.NewLine));

                try
                {
                    String[] lines;
                    lines = File.ReadAllLines(polku);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        Console.WriteLine(lines[i]);
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine("Tiedostoa ei voida lukea.");
                    Console.WriteLine(e.Message);
                }
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
