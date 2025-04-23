using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._04._202555
{


    namespace SortTimerWithReflection
    {
        // Клас, представящ човек с име и възраст
        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }

        // Сравнител по възраст
        public class AgeComparer : IComparer<Person>
        {
            public int Compare(Person? x, Person? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                return x.Age.CompareTo(y.Age);
            }
        }

        // Сравнител по име
        public class NameComparer : IComparer<Person>
        {
            public int Compare(Person? x, Person? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            }
        }

        public class Program
        {
            public static void Main()
            {
                // Генерираме списък с 1000 случайни човека
                List<Person> people = GeneratePeople(1000);

                // Два различни метода за сортиране: по възраст и по име
                IComparer<Person>[] comparers = { new AgeComparer(), new NameComparer() };

                // Сортиране и измерване на времето за всеки метод
                foreach (var comparer in comparers)
                {
                    List<Person> peopleCopy = new List<Person>(people); // Копие, за да не се влияе от предходното сортиране
                    Stopwatch stopwatch = Stopwatch.StartNew(); // Стартиране на таймера
                    peopleCopy.Sort(comparer); // Сортиране
                    stopwatch.Stop(); // Спиране на таймера

                    Console.WriteLine($"Сортиране с {comparer.GetType().Name} отне {stopwatch.Elapsed.TotalMilliseconds} ms.");
                }

                // Извеждане на информация чрез Reflection
                Console.WriteLine("\nИнформация чрез Reflection:");
                foreach (var comparer in comparers)
                {
                    Type type = comparer.GetType();
                    Console.WriteLine($"Тип: {type.FullName}");
                    Console.WriteLine($"Сборка: {type.Assembly.GetName().Name}");

                    Console.WriteLine("Методи:");
                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine($"- {method.Name}");
                    }

                    Console.WriteLine("Имплементирани интерфейси:");
                    foreach (var iface in type.GetInterfaces())
                    {
                        Console.WriteLine($"- {iface.FullName}");
                    }

                    Console.WriteLine();
                }
            }

            // Метод за генериране на списък от случайни хора
            private static List<Person> GeneratePeople(int count)
            {
                Random random = new Random();
                List<Person> people = new List<Person>();

                for (int i = 0; i < count; i++)
                {
                    people.Add(new Person
                    {
                        Name = GenerateRandomName(random),
                        Age = random.Next(1, 100)
                    });
                }

                return people;
            }

            // Метод за генериране на случайно име
            private static string GenerateRandomName(Random random)
            {
                int nameLength = random.Next(5, 10); // Дължина на името между 5 и 9
                char[] nameChars = new char[nameLength];

                for (int i = 0; i < nameLength; i++)
                {
                    nameChars[i] = (char)('a' + random.Next(0, 26)); // Буква от 'a' до 'z'
                }

                return new string(nameChars);
            }
        }
    }
}