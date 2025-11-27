using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_33_RPM
{
    public class ChatAnalyzer
    {
        private List<string> allMessages = new List<string>();
        private Dictionary<string, int> userMessageCount = new Dictionary<string, int>();
        private Dictionary<string, int> userWordCount = new Dictionary<string, int>();

        public void LoadMessages(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    allMessages.Add(line);

                    // сообщение вида "user: текст..."
                    var parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        var user = parts[0];
                        if (!userMessageCount.ContainsKey(user))
                            userMessageCount[user] = 1;
                        else
                            userMessageCount[user]++;

                        var words = parts[1].Split(' ');
                        if (!userWordCount.ContainsKey(user))
                            userWordCount[user] = words.Length;
                        else
                            userWordCount[user] += words.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка загрузки: " + ex.Message);
            }
        }

        public string GetTopUser()
        {
            int max = 0;
            string name = "";
            foreach (var u in userMessageCount)
            {
                if (u.Value > max)
                {
                    max = u.Value;
                    name = u.Key;
                }
            }
            return name + " (" + max + ")";
        }

        public double GetAverageMessageLength()
        {
            int total = 0;
            int count = 0;

            foreach (var m in allMessages)
            {
                var p = m.Split(':');
                if (p.Length >= 2)
                {
                    total += p[1].Split(' ').Length;
                    count++;
                }
            }

            if (count == 0) return 0;
            return total / count;   // ← Ошибка! целочисленное деление
        }

        public int CountMessagesFromUser(string user)
        {
            int c = 0;
            foreach (var m in allMessages)
            {
                if (m.StartsWith(user + ":"))
                    c++;
            }
            return c;
        }
    }
}

