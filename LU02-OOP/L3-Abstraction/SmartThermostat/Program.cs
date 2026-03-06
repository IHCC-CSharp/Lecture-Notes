SmartThermostat nest = new SmartThermostat("Eco-V1", 65.0);

nest.CurrentTemp = 500.0; 
// The object silently rejected 500.0 because of our 'if' logic in the setter.
Console.WriteLine($"Attempted 500°F. {nest.GetStatus()}");

// Set a valid temperature
nest.CurrentTemp = 75.0;
Console.WriteLine($"Attempted 75°F. {nest.GetStatus()}");

