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
        public EnigmaMachine()
        {
            Rotors = new List<Rotor>();
        }
        public void SetReflector(string input, string output)
        {
            Reflector = new Reflector(input.ToUpper(), output.ToUpper());
        }
        public void SetCommutator(string chars)
        {
            Commutator = new Commutator(chars.ToUpper());
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
        public void RemoveRotor(Rotor rotor)
        {
            Rotors.Remove(rotor);
        }
        public void ChangeRotor(Rotor rotor, int position)
        {
            Rotors[position - 1] = rotor;
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
            if (!Constants.regexMess.IsMatch(message)) throw new ArgumentException("Wrong chars in message");
            char res;
            message = message.ToUpper();
            string encrypted_message = "";
            foreach (char c in message)
            {
                if (c == ' ')
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
        public void SaveConfig()
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\danil\source\repos\Enigma\Enigma\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
                serializer.Serialize(file, this);
            }
        }
        public void ConnectRotors()
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
    }
}
