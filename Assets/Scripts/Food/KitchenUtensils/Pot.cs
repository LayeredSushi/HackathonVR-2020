using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : KitchenUtensil
{
    public bool IsRefilled = false;
    private new void Update()
    {
        if (IsRefilled)
            base.Update();
    }

    public IEnumerator RefillWater()
    {
        return null;
    }
}
