﻿using System.Collections;
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

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("aaaa");

        if (collision.gameObject.GetType() == typeof(KitchenUtensil))
        {
            if(!utensil)
                utensil = collision.gameObject.GetComponent<KitchenUtensil>();
            
            if(utensil.temperature < 300)
            {
                utensil.temperature += 0.05f;
            }
        }
    }
}
