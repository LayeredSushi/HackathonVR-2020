using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSpawnUnit : MonoBehaviour
{
    public FoodItem prefab;

    private void Awake()
    {
        Instantiate(prefab);
    }

    private void OnTriggerExit(Collider other)
    {
        Instantiate(prefab);
    }
}
