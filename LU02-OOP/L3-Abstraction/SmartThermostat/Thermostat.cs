public class SmartThermostat
{
    // Auto-Implemented Property (The "Simple" way)
    // Use this when no validation logic is needed.
    public string ModelName { get; set; }

    // Field-Backed Property (The "Manual" way)
    // this field actually holds the data.
    private double _currentTemp;

    // This is our getter and setter
    public double CurrentTemp
    {
        get { return _currentTemp; }
        set
        {
            // temperatures between 55°F and 95°F
            if (value >= 55 && value <= 95)
            {
                _currentTemp = value;
            }
            // If invalid, we simply don't update
        }
    }

    public SmartThermostat(string model, double startingTemp)
    {
        ModelName = model;
        CurrentTemp = startingTemp;
    }

    public string GetStatus()
    {
        return $"Thermostat {ModelName} is set to {CurrentTemp}°F.";
    }
}