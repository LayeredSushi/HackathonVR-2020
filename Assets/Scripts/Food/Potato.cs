using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : FoodItem
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My life is POTATO");
    }

    public new void  Update()
    {
        base.Update();
        Cook();
    }
    
    public override void Cook()
    {
        if (IsProcessed)
            base.Cook();
    }
}
