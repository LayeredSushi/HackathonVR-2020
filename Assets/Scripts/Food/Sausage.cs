using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : FoodItem
{
    new void Update()
    {
        base.Update();
        base.Cook();   
    }
}
