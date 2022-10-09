using Enigma.Utils;
using Newtonsoft.Json;

namespace Enigma.Tools
{
    public class Reflector
    {
        [JsonRequired]
        private readonly string input;
        [JsonRequired]
        private readonly string output;

        public Reflector()
        {
            input = Constants.alphabet.Substring(0, 16);
            output = Constants.alphabet.Substring(16);
        }
        public Reflector(string input, string output) : this()
        {
            if (!Constants.regex.IsMatch(input)) throw new ArgumentException("Wrong chars in Reflector input");
            if (!Constants.regex.IsMatch(output)) throw new ArgumentException("Wrong chars in Reflector output");
            if (input.Length != 16 || output.Length != 16) throw new IndexOutOfRangeException("Length of input and output must be equal 16");
            this.input = input.ToUpper();
            this.output = output.ToUpper();
        }

        public char Reflect(char input)
        {
            if (this.input.Contains(input)) return output[this.input.IndexOf(input)];
            if (output.Contains(input)) return this.input[output.IndexOf(input)];
            throw new Exception("Char not found");
        }
    }
}
