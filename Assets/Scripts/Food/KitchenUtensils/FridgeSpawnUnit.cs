using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSpawnUnit : MonoBehaviour
{
    public FoodItem[] prefabs;
    public int index;

    private FridgeSpawnUnit[] fridgeSpawnUnits;
    void Start()
    {
        fridgeSpawnUnits = GetComponentsInChildren<FridgeSpawnUnit>();
    }

    private void OnCollisionExit(Collision collision)
    {
        Instantiate(prefabs[index]);
    }
}
