using Enigma.Utils;
using Newtonsoft.Json;

namespace Enigma.Tools
{
    public class Rotor
    {
        [JsonRequired]
        private string chars;
        [JsonIgnore]
        public int currentIndex { get; private set; } = 0;
        [JsonIgnore]
        public int rotations { get; private set; } = 0;
        public Rotor Next { get; set; }
        public Rotor Previos { get; set; }
        [JsonRequired]
        public RotorType Type { get; }

        public Rotor() 
        {
            chars = Constants.alphabet;
            rotations = 0;
        }
        public Rotor(RotorType type) : this()
        {
            Type = type;
            chars = Constants.alphabet;
            rotations = 0;
        }
        public Rotor(RotorType type, string chars) : this(type)
        {
            if (!Constants.regex.IsMatch(chars)) throw new ArgumentException("Wrong chars in Rotor string");
            if (chars.Length != 32) throw new ArgumentOutOfRangeException("Length of Rotor's chars must be equal 32.");
            Type = type;
            this.chars = chars.ToUpper();
            rotations = 0;
        }

        public void SetLetter(char start)
        {
            if (!Constants.regex.IsMatch(chars)) throw new ArgumentException("Wrong Letter for Key");
            currentIndex = chars.IndexOf(char.ToUpper(start));
            rotations = 0;
        }
        public void Rotate()
        {
            currentIndex++;
            currentIndex %= Constants.alphabetLength;

            rotations++;
            if(rotations == Constants.alphabetLength - 1)
            {
                rotations = 0;
                if(Next != null)
                {
                    Next.Rotate();
                }
            }
        }
        public char EntryOnExit(char input)
        {
            int add, final;
            if (Type == RotorType.Rotor_I) return input;
            add = Previos.chars.IndexOf(char.ToUpper(input)) - Previos.currentIndex;
            final = (currentIndex + add + Constants.alphabetLength) % Constants.alphabetLength;
            return chars[final];
        }
        public char ExitOnEntry(char input)
        {
            int add, final;
            if (Type == RotorType.Rotor_III) return input;
            add = Next.chars.IndexOf(char.ToUpper(input)) - Next.currentIndex;
            final = (currentIndex + add + Constants.alphabetLength) % Constants.alphabetLength;
            return chars[final];
        }
        public void ChangeRotorChars(string chars)
        {
            if (!Constants.regex.IsMatch(chars)) throw new ArgumentException("Wrong chars in Commutator chars string");
            if (chars.Length != 32) throw new ArgumentOutOfRangeException(nameof(this.chars));
            this.chars = chars.ToUpper();
        }
    }
}
