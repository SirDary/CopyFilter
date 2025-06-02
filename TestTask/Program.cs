namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CopyFilter filter = new CopyFilter();

            Console.WriteLine("Демонстрация работы CopyFilter");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Введите адреса через пробел");
            List<string> to = [];
            List<string> copys = [];
            try
            {
                Console.Write("Кому:");
                to = Console.ReadLine().Replace(";", "")
                    .Split(" ")
                    .ToList();

                Console.Write("Копии:");
                copys = Console.ReadLine().Replace(";", "")
                    .Split(" ")
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var result = filter.Filter(to, copys);

            Console.WriteLine();
            Console.WriteLine("\tРезультат");
            Console.WriteLine("--------------------------------");

            Console.Write("Кому: ");
            foreach (var item in to)
                Console.Write(item + "; ");

            Console.Write("\nКопии: ");
            foreach (var item in result)
                Console.Write(item + "; ");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
