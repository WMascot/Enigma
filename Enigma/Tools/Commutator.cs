using Enigma.Utils;
using Newtonsoft.Json;

namespace Enigma.Tools
{
    public class Commutator
    {
        [JsonRequired]
        private readonly string chars;

        public Commutator()
        {
            chars = Constants.alphabet;
        }
        public Commutator(string chars) : this()
        {
            if (!Constants.regex.IsMatch(chars)) throw new ArgumentException("Wrong chars in Commutator chars string");
            if (chars.Length != 32) throw new ArgumentOutOfRangeException(nameof(this.chars));
            this.chars = chars.ToUpper();
        }

        public char EntryOnExit(char input)
        {
            int index = Constants.alphabet.IndexOf(input);
            return chars[index];
        }
        public char ExitOnEntry(char input)
        {
            int index = chars.IndexOf(input);
            return Constants.alphabet[index];
        }
    }
}
