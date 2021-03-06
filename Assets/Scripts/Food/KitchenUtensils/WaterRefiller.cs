using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pot>() != null)
        {
            Pot pot = other.gameObject.GetComponent<Pot>();
            StartCoroutine(pot.RefillWater());
        }
    }
}
