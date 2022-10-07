using Enigma.MainMachine;
using Enigma.Utils;
using Newtonsoft.Json;

string str;
string key;
string encryption;
string decryption;


EnigmaMachine Enigma = EnigmaMachine.LoadConfig();

//EnigmaMachine Enigma = new();

//Enigma.SetReflector("МНЩЮЗЫФИДЛХТПАРЬ", "ЪСЙВУКЦЭШЖБГОЕЧЯ");
//Enigma.SetCommutator("ЗЦЮШПДЬЧЩОНЖЙТЛХИБЯЫФРГЕАЪЭУКМВС");

//Enigma.CreateRotors(3);

//Enigma.SetRotor(1, "ЮЕМДЛСКОБПЫЭЖФЦАЬЩЙЗГШЧТРЯЪХУВИН");
//Enigma.SetRotor(2, "ЕФМЦЗУХОКАШЭРЯЮЛИВПЪЬТЙЧНЩГЫЖДБС");
//Enigma.SetRotor(3, "ЭЧИЖВЪШЮХЬКДПЛЙЩБФТОУСГЦРЕЫЯАМНЗ");

//EnigmaMachine.SaveConfig(Enigma);

//Enigma.ConnectRotors();

Console.WriteLine("Введите сообщение: ");
str = Console.ReadLine();

Console.WriteLine("Введите ключ: ");
key = Console.ReadLine();

Enigma.SetKey(key);

encryption = Enigma.Encrypt(str);

Console.WriteLine(encryption);

Enigma.SetKey(key);

decryption = Enigma.Encrypt(encryption);

Console.WriteLine(decryption);