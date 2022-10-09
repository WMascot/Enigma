using System.Text.RegularExpressions;

namespace Enigma.Utils
{
    public class Constants
    {
        public static string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public const int alphabetLength = 32;
        public static Regex regex = new Regex(@"^[а-яА-Я]+$");
        public static Regex regexMessageFalse = new Regex(@"[a-zA-Z]");
        public static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
    }
}
