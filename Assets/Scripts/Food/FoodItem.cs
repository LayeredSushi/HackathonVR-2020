public abstract class FoodItem : Grabbable
{
    public float temperature;
    public float maximumTemperature;
    public bool isSpoiled = false;

    private void Update()
    {
        if (temperature > maximumTemperature)
            isSpoiled = true;
    }
}
