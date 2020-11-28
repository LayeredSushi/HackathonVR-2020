public abstract class FoodItem : Grabbable
{
    public float temperature;
    public float maximumTemperature;
    public float cookingTime = 20f;
    public bool isSpoiled = false;

    private void Update()
    {
        if (temperature > maximumTemperature)
            isSpoiled = true;
    }
}
