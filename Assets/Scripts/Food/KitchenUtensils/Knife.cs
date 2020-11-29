using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : Grabbable
{
    private bool _IsActive = false;
    public bool IsActive
    {
        get { return _IsActive; }
        set
        {
            if (IsActive) _IsActive = false;
            else if (!IsActive) _IsActive = true;
        }
    }

    public override void OnInteraction(HandManager handManager, PointerEventArgs args)
    {
        base.OnInteraction(handManager, args);
        IsActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FoodItem>()!=null && !other.gameObject.GetComponent<FoodItem>().IsProcessed)
        {
            other.gameObject.GetComponent<FoodItem>().ProcessFood();
        }
    }

}
