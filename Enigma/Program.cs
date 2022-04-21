using Enigma.MainMachine;
using Newtonsoft.Json;

string str;
string key;
string encryption;
string decryption;

EnigmaMachine Enigma = new EnigmaMachine();

using (StreamReader file = File.OpenText(@"C:\Users\danil\source\repos\Enigma\Enigma\config.json"))
{
    JsonSerializer serializer = new JsonSerializer();
    serializer.Formatting = Formatting.Indented;
    serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
    Enigma = (EnigmaMachine)serializer.Deserialize(file, typeof(EnigmaMachine));
}

Enigma.ConnectRotors();

Console.WriteLine("Введите сообщение: ");
str = Console.ReadLine();

Console.WriteLine("Введите ключ: ");
key = Console.ReadLine();

Enigma.SetKey(key);

encryption = Enigma.Encrypt(str);

Console.WriteLine(encryption);

Enigma.SetKey(key);

decryption = Enigma.Encrypt(encryption);

Console.WriteLine(decryption.Replace(" ТЧК", ".").Replace(" ЗПТ", ","));