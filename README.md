<h1>How to use</h1>
<h2>1. Create Enigma and Rotors, then Add Rotors</h2>

```C#
	EnigmaMachine Enigma = new EnigmaMachine();
	
	Rotor first = new Rotor(RotorType.Rotor_I ,"ЮЕМДЛСКОБПЫЭЖФЦАЬЩЙЗГШЧТРЯЪХУВИН");
	Rotor second = new Rotor(RotorType.Rotor_II, "ЕФМЦЗУХОКАШЭРЯЮЛИВПЪЬТЙЧНЩГЫЖДБС");
	Rotor third = new Rotor(RotorType.Rotor_III, "ЭЧИЖВЪШЮХЬКДПЛЙЩБФТОУСГЦРЕЫЯАМНЗ");

	Enigma.AddRotor(first);
	Enigma.AddRotor(second);
	Enigma.AddRotor(third);
```
	
<h2>2. Create Reflector and Commutator within the Enigma</h2>

```C#
  	Enigma.SetReflector("МНЩЮЗЫФИДЛХТПАРЬ", "ЪСЙВУКЦЭШЖБГОЕЧЯ");
  	Enigma.SetCommutator("ЗЦЮШПДЬЧЩОНЖЙТЛХИБЯЫФРГЕАЪЭУКМВС");
```  	

<h2>3. Set Key for Enigma</h2>

```C#
	Enigma.SetKey("КПР");
```

<h2>4. Encrypt any message using spaces and Russian Letters except for "Й"</h2>

```C#
	string encryption = Enigma.Encrypt("Шла Саша по шоссе и сосала сушку");
```

<h2>Result</h2>
ЬЦЮ ЭУЛС ВЯ ХЪЙДЪ Щ ЕДЩЛЙТ ВШКЭЦ
