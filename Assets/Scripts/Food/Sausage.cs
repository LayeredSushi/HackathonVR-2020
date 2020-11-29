public class Sausage : FoodItem
{
    new void Update()
    {
        base.Update();
        base.Cook();   
    }
}
