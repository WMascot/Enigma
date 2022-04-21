using Enigma.Utils;
using Newtonsoft.Json;

namespace Enigma.Tools
{
    public class Commutator
    {
        [JsonRequired]
        private readonly string chars;
        public Commutator(string chars)
        {
            if (!Constants.regex.IsMatch(chars)) throw new ArgumentException("Wrong chars in Commutator chars string");
            if (chars.Length != 32) throw new ArgumentOutOfRangeException("Length of Commutator's chars must be equal 32.");
            this.chars = chars.ToUpper();
        }
        public char EntryOnExit(char input)
        {
            int index = Array.IndexOf(Constants.alphabet, input);
            return chars[index];
        }
        public char ExitOnEntry(char input)
        {
            int index = chars.IndexOf(input);
            return Constants.alphabet[index];
        }
    }
}
