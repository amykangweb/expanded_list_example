using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    class Animals
    {
        public List<Cats> arrayOfCats = new List<Cats>();

        public void Add(Cats cat)
        {
            int alreadyExist = arrayOfCats.FindIndex(f => f.Name.ToLower() == cat.Name.ToLower());
            if (alreadyExist >= 0)
            {
                Console.WriteLine("That cat already exists in the database");
                return;
            }
            else
            {
                arrayOfCats.Add(cat);
            }
        }

        public void Remove(string name)
        {
            foreach (var cat in arrayOfCats.ToList())
            {
                if (cat.Name.ToLower() == name.ToLower())
                {
                    arrayOfCats.Remove(cat);
                    return;
                }
            }
            Console.WriteLine("That cat does not exist in the database.");
        }

        public void AllCats()
        {
            foreach (var cat in arrayOfCats)
            {
                Console.WriteLine(cat.Name);
            }
        }
    }
    class Cats
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animals animals = new Animals();
            Cats cat1 = new Cats();
            cat1.Name = "Wilbur";
            animals.Add(cat1);

            animals.AllCats();

            while(true)
            {
                Console.WriteLine("Enter exit to quit program or remove to remove a cat.");
                Console.Write("Enter new cat's name: ");
                Cats cat2 = new Cats();
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Bye Bye!");
                    break;
                }
                else if (input.ToLower() == "remove")
                {
                    Console.Write("Enter name of cat you want to remove: ");
                    string removeName = Console.ReadLine();
                    animals.Remove(removeName);
                    animals.AllCats();
                }
                else {
                    cat2.Name = input;
                    animals.Add(cat2);
                    Console.WriteLine("Printing all cats...");
                    animals.AllCats();
                }
            }
            Console.Read();
        }
    }
}
