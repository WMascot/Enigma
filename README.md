Enigma

<h1>How to use</h1>
<h2>1. Create Enigma and Rotors, then Add Rotors<h2>
  `EnigmaMachine Enigma = new EnigmaMachine();

  Rotor first = new Rotor(RotorType.Rotor_I ,"ЮЕМДЛСКОБПЫЭЖФЦАЬЩЙЗГШЧТРЯЪХУВИН");
  Rotor second = new Rotor(RotorType.Rotor_II, "ЮЕМДЛСКОБПЫЭЖФЦАЬЩЙЗГШЧТРЯЪХУВИН");
  Rotor third = new Rotor(RotorType.Rotor_III, "ЮЕМДЛСКОБПЫЭЖФЦАЬЩЙЗГШЧТРЯЪХУВИН");

  Enigma.AddRotor(first);
  Enigma.AddRotor(second);
  Enigma.AddRotor(third);`
