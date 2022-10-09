using Enigma.Tools;
using Enigma.Utils;
using Newtonsoft.Json;

namespace Enigma.MainMachine
{
    public class EnigmaMachine
    {
        [JsonRequired]
        public List<Rotor> Rotors { get; private set; }
        [JsonRequired]
        public Reflector Reflector { get; private set; }
        [JsonRequired]
        public Commutator Commutator { get; private set; }

        [JsonConstructor]
        public EnigmaMachine()
        {
            Rotors = new List<Rotor>();
            Reflector = new Reflector();
            Commutator = new Commutator();
        }

        public void SetReflector(string input, string output)
        {
            Reflector = new Reflector(input.ToUpper(), output.ToUpper());
        }
        public void SetCommutator(string chars)
        {
            Commutator = new Commutator(chars.ToUpper());
        }
        public void SetRotor(int index, string chars)
        {
            if (index < 1 || index > Rotors.Count) throw new ArgumentOutOfRangeException(nameof(Rotors)); 
            Rotor rotor = Rotors[index - 1];
            rotor.ChangeRotorChars(chars);
        }
        public void CreateRotors(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Rotors.Add(new Rotor());
            }
            ConnectRotors();
        }
        public void AddRotor(Rotor rotor)
        {
            Rotors.Add(rotor);
            if (Rotors.Count > 1)
            {
                int index = Rotors.IndexOf(rotor);
                Rotors[index].Previos = Rotors[index - 1];
                Rotors[index - 1].Next = Rotors[index];
            }
        }
        public void SetKey(string key)
        {
            key = key.ToUpper();
            for (int i = 0; i < Rotors.Count; i++)
            {
                Rotors[i].SetLetter(key[i]);
            }
        }
        public string Encrypt(string message)
        {
            if (Constants.regexMessageFalse.IsMatch(message)) throw new ArgumentException("Wrong chars in message");
            char res;
            message = message.ToUpper();
            string encrypted_message = "";
            foreach (char c in message)
            {
                if (!Constants.alphabet.Contains(c))
                {
                    encrypted_message += c;
                    continue;
                }
                res = Commutator.EntryOnExit(c);
                for (int i = 0; i < Rotors.Count; i++)
                {
                    res = Rotors[i].EntryOnExit(res);
                }
                res = Reflector.Reflect(res);
                for (int i = Rotors.Count - 1; i >= 0; i--)
                {
                    res = Rotors[i].ExitOnEntry(res);
                }
                res = Commutator.ExitOnEntry(res);
                Rotors[0].Rotate();
                encrypted_message += res;
            }
            return encrypted_message;
        }

        private void ConnectRotors()
        {
            for (int i = 0; i < Rotors.Count; i++)
            {
                if (i > 0)
                {
                    Rotors[i].Previos = Rotors[i - 1];
                    Rotors[i - 1].Next = Rotors[i];
                }
            }
        }

        public static void SaveConfig(EnigmaMachine enigmaMachine)
        {
            using (StreamWriter file = File.CreateText(Constants.configPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
                serializer.Serialize(file, enigmaMachine);
            }
        }
        public static EnigmaMachine LoadConfig()
        {
            if (!File.Exists(Constants.configPath)) throw new FileNotFoundException("Config file doesnt exist");
            using (StreamReader file = File.OpenText(Constants.configPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
                return (EnigmaMachine)serializer.Deserialize(file, typeof(EnigmaMachine));
            }
        }
    }
}
