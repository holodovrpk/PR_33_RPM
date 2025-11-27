namespace PR_33_RPM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Анализатор чата (плохая версия) ===");

            ChatAnalyzer analyzer = new ChatAnalyzer();
            analyzer.LoadMessages("messages.txt");

            Console.WriteLine("\nТоп пользователь по числу сообщений:");
            Console.WriteLine(analyzer.GetTopUser());

            Console.WriteLine("\nСредняя длина сообщения (в словах):");
            Console.WriteLine(analyzer.GetAverageMessageLength());

            Console.Write("\nВведите имя пользователя: ");
            string user = Console.ReadLine();
            Console.WriteLine("Сообщений от пользователя: " +
                analyzer.CountMessagesFromUser(user));

            Console.WriteLine("\nРабота завершена.");
        }
    }
}
