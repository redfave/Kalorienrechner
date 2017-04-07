using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var go = true;
            while (go)
            {
                Console.Write(
                    @"Bitte wählen Sie aus folgenden Optionen:
Neues Rezept (1)
Neue Zutat (2)
Zutaten anzeigen (3)
Rezepte anzeigen (4)
Beenden (5)
");
                var action = Console.ReadKey().KeyChar;
                switch (action)
                {
                    case '1':

                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    case '4':

                        break;
                    case '5':

                        break;
                }
            }
        }

        public void CreateNewRecipe()
        {

        }
    }
}
