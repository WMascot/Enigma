using Enigma.MainMachine;
using Enigma.Utils;
using Newtonsoft.Json;

string str;
string key;
string encryption;
string decryption;

EnigmaMachine Enigma = new EnigmaMachine();

Enigma = Enigma.LoadConfig();

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