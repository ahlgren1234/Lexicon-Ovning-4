using System;

namespace SkalProj_Datastrukturer_Minne
{

    //
    //
    // OBS: SVAR PÅ FRÅGORNA LIGGER LÄNGST NER I FILEN!
    //
    //
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Reverse Text"
                    + "\n6. Rekursiv (jämna tal)"
                    + "\n7. Rekursiv Fibonacci"
                    + "\n8. Iterative Even"
                    + "\n9. Iterative Fibonacci"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        ReverseText();
                        break;
                    case '6':
                        Console.WriteLine("Skriv n för jämnt tal:");
                        int nEven = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Det {nEven}:e jämna talet är: {RecursiveEven(nEven)}");
                        break;
                    case '7':
                        Console.WriteLine("Skriv n för Fibonacci:");
                        int nFib = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Fibonacci({nFib}) = {RecursiveFibonacci(nFib)}");
                        break;
                    case '8':
                        Console.WriteLine("Skriv n för IterativeEven:");
                        if (int.TryParse(Console.ReadLine(), out int nEven2))
                            Console.WriteLine($"Jämna tal nr {nEven2} är: {IterativeEven(nEven2)}");
                        break;
                    case '9':
                        Console.WriteLine("Skriv n för IterativeFibonacci:");
                        if (int.TryParse(Console.ReadLine(), out int nFib2))
                            Console.WriteLine($"Fibonacci({nFib2}) = {IterativeFibonacci(nFib2)}");
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +namn för att lägga till, -namn för att ta bort, eller tryck Enter för att gå tillbaka till menyn:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Tillbaka till huvudmenyn.");
                    break;
                }

                char operation = input[0];
                string value = input.Substring(1).Trim();

                switch (operation)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"'{value}' lades till.");
                        break;
                    case '-':
                        if (theList.Remove(value))
                            Console.WriteLine($"'{value}' togs bort.");
                        else
                            Console.WriteLine($"'{value}' hittades inte i listan.");
                        break;
                    default:
                        Console.WriteLine("Ange + eller - följt av ett namn.");
                        break;
                }

                Console.WriteLine($"Antal element i listan: {theList.Count}, Kapacitet: {theList.Capacity}");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +namn för att ställa någon i kön, '-' för att expediera först i kön, eller tryck Enter för att gå tillbaka:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Tillbaka till huvudmenyn.");
                    break;
                }

                char command = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                switch (command)
                {
                    case '+':
                        if (!string.IsNullOrEmpty(value))
                        {
                            queue.Enqueue(value);
                            Console.WriteLine($"{value} har ställt sig i kön.");
                        }
                        else
                        {
                            Console.WriteLine("Du måste skriva ett namn efter '+'.");
                        }
                        break;

                    case '-':
                        if (queue.Count > 0)
                        {
                            string served = queue.Dequeue();
                            Console.WriteLine($"{served} blev expedierad och lämnade kön.");
                        }
                        else
                        {
                            Console.WriteLine("Kön är tom - ingen att expediera.");
                        }
                        break;

                    default:
                        Console.WriteLine("Använd '+' för att lägga till, '-' för att ta bort.");
                        break;
                }

                // VIsa aktuell kö
                Console.WriteLine("Aktuell kö: " + (queue.Count > 0 ? string.Join(", ", queue) : "Tom"));
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\nSkriv +text för att lägga till i stacken, '-' för att ta bort översta, eller tryck Enter för att avsluta:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Tillbaka till huvudmenyn.");
                    break;
                }

                char command = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                switch (command)
                {
                    case '+':
                        if (!string.IsNullOrEmpty(value))
                        {
                            stack.Push(value);
                            Console.WriteLine($"'{value}' har lagts på stacken.");
                        }
                        else
                        {
                            Console.WriteLine("Ange något efter '+'.");
                        }
                        break;

                    case '-':
                        if (stack.Count > 0)
                        {
                            string removed = stack.Pop();
                            Console.WriteLine($"'{removed}' har tagits bort från stacken.");
                        }
                        else
                        {
                            Console.WriteLine("STacken är tom.");
                        }
                        break;

                    default:
                        Console.WriteLine("Använd '+' eller '-' som första tecken.");
                        break;
                }

                Console.WriteLine("Aktuell stack (överst först): " + (stack.Count > 0 ? string.Join(", ", stack) : "Tom"));
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("\nSkriv en text du vill vända:");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.Write("Omvänd text: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("\nSkriv en sträng med paranteser som ska kontrolleras:");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char> ();
            Dictionary<char, char> match = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in input)
            {
                if (c == '(' || c == '{' | c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != match[c])
                    {
                        Console.WriteLine("Nope! Strängen är INTE välformad.");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Yeah! Strängen ÄR välformad.");
            }
            else
            {
                Console.WriteLine("Nope! Strängen är INTE välformad.");
            }
        }

        static int RecursiveEven(int n)
        {
            if (n == 1)
                return 2;
            return RecursiveEven(n - 1) + 2;
        }

        static int RecursiveFibonacci(int n)
        {
            if (n <= 1)
                return n;
            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 1; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        static int IterativeFibonacci(int n)
        {
            if (n <= 1)
                return n;

            int a = 0, b = 1, result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }

    }
}

/* FRÅGA 1:
 * 
 * Stacken och heapen är två olika delar av minnet där olika typer av data lagras.
 * 
 * Stacken fungerar som en stapel (LIFO – Last In First Out). Varje gång en metod anropas läggs dess lokala variabler och anropsinformation högst upp på stacken. När metoden är klar tas denna information automatiskt bort.
 * 
 * Exempel:
 * void MyMethod() {
 *     int x = 5; // 'x' är en värdetyp och lagras på stacken.
 * }
 * 
 * När metoden är färdig körd tas allt på stacken bort automatiskt.
 * 
 * Heapen är däremot en minnesyta där objekt (referenstyper) lagras. Det är ett mer fritt organiserat minne som hanteras av .NET:s Garbage Collector (GC).
 * När vi skapar objekt med t.ex. 'new', lagras det på heapen och en referens till objektet lagras på stacken.
 * 
 * Exempel:
 * class MyClass {
 *     public int MyValue;
 * }
 * 
 * void MyMethod() {
 *     MyClass obj = new MyClass(); // Referensen 'obj' ligger på stacken, själva objektet på heapen.
 * }
 * 
 * Heapen behöver städas manuellt av Garbage Collector eftersom den inte töms automatiskt som stacken.
 * 
 * En liknelse:
 * - Stacken är som en trave skokartonger där du bara kommer åt den översta (metod-anrop i ordning).
 * - Heapen är som en hög med kläder på en säng där du kan plocka vad du vill – men det kan bli stökigt och behöver städas ibland (GC).
 */


/* FRÅGA 2:
 * 
 * Value Types (värdetyper) och Reference Types (referenstyper) är två grundläggande kategorier av datatyper i C#.
 * 
 * Value Types:
 * - Innehåller själva värdet.
 * - Lagrade direkt på stacken (om de är lokala variabler) eller inuti ett objekt på heapen.
 * - När en value type kopieras (t.ex. int x = y), skapas en ny kopia av värdet.
 * - Exempel: int, float, double, bool, char, struct, enum
 * 
 * Reference Types:
 * - Innehåller en referens (pekare) till ett objekt som ligger på heapen.
 * - När en reference type kopieras (t.ex. MyClass a = b), kopieras referensen, inte själva objektet.
 * - Flera variabler kan alltså peka på samma objekt.
 * - Exempel: class, interface, delegate, string, object
 * 
 * Exempel:
 * int a = 5;
 * int b = a;    // b får en kopia av värdet 5 – a och b är oberoende av varandra.
 * 
 * MyClass obj1 = new MyClass();
 * MyClass obj2 = obj1; // obj2 pekar på samma objekt som obj1 – ändringar via den ena påverkar den andra.
 * 
 * Skillnad:
 * - Value Types hanterar sitt egna värde direkt, medan Reference Types arbetar via referenser till objekt.
 * - Value Types skapas oftast på stacken, Reference Types på heapen.
 */


/* FRÅGA 3:
 * 
 * Skälet till att det första exemplet returnerar 3, är att det är en Value Type, Det är värdet av variabeln X
 * som kopieras in i variabeln Y. När sedan Y ändras finns ingen direkt koppling till X, som då har kvar 
 * sitt gamla värde (3).
 * 
 * I det andra exemplet handlar det om Reference types, Där kopieras en referens till värdet in i Y från X.
 * När sedan värdet i Y ändras, kommer även värdet i X ändras eftersom de båda innhåller varsin pekare till
 * samma värde.
 * 
 * Slutsats:
 * - Value Types skickas som kopior → originalet påverkas inte.
 * - Reference Types skickas som referenser → ändringar syns utanför metoden.
 */

/* ÖVNING 1:
 * 
 * Punkt 2: Listans kapacitet ökar automatiskt när antalet element i listan överskrider den nuvarande kapaciteten.
 *  när du lägger till ett nytt element och listans interna array är full, så skapas en ny större array bakom 
 *  kulisserna och de gamla elementen kopieras över.
 *  
 *  Punkt 3: Kapaciteten ökar med det dubbla.
 *  
 *  Punkt 4: 
 *  För att förbättra prestanda ökar List<T> kapaciteten exponentiellt snarare än
 *  linjärt. Om kapaciteten ökade med bara 1 för varje nytt element, skulle varje
 *  tillägg efter maxkapacitet kräva att en ny array skapas och alla element kopieras,
 *  vilket är mycket ineffektivt (O(n²) komplexitet).
 *
 *  Genom att öka kapaciteten med t.ex. 100 %, minskar antalet gånger som denna
 *  omallokering och kopiering måste ske, vilket gör det mycket mer minnes- och
 *  tids-effektivt över tid.
 *  
 *  Punkt 5: 
 *  Nej, kapaciteten minskar inte automatiskt när element tas bort från en List<T>.
 *  Endast antalet element (Count) minskar, medan den interna arrayens storlek (Capacity) 
 *  förblir oförändrad.
 *  
 *  Punkt 6:
 *  När antalet element är känt i förväg.
 *  När prestanda och minnesåtgång är kritiska.
 *  
 *  
 */



