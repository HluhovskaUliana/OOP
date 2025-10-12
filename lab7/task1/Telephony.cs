using System;

namespace SmartphoneApp
{
    public interface ICallable
    {
        string Call(string number);
    }

    public interface IBrowsable
    {
        string Browse(string url);
    }

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            foreach (char ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return "Invalid number!";
                }
            }
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {url}";
        }
    }

    class Telephony
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone phone = new();

            foreach (string number in numbers)
            {
                Console.WriteLine(phone.Call(number));
            }

            foreach (string url in urls)
            {
                Console.WriteLine(phone.Browse(url));
            }
        }
    }
}
