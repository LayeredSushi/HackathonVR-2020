using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{

    KitchenUtensil utensil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        utensil = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!utensil)
        {
            utensil = other.gameObject.GetComponent<KitchenUtensil>();
        }

        if (utensil)
        {
            if (utensil.temperature < 300)
            {
                utensil.temperature += 0.05f;
            }
        }
    }
}
