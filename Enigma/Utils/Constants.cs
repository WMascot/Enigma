using System.Text.RegularExpressions;

namespace Enigma.Utils
{
    public class Constants
    {
        public static char[] alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        public const int alphabetLength = 32;
        public static Regex regex = new Regex(@"^[а-яА-Я]+$");
        public static Regex regexMess = new Regex(@"^[а-я\sА-Я]+$");
    }
}
