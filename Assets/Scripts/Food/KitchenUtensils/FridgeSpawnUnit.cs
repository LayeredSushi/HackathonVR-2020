using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSpawnUnit : MonoBehaviour
{
    public FoodItem prefab;

    public float spawnCooldown;
    private bool spawnable;

    private void Awake()
    {
        Instantiate(prefab, gameObject.transform);
        spawnable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (spawnable)
            StartCoroutine(SpawnNewAfterSeconds());
    }

    IEnumerator SpawnNewAfterSeconds()
    {
        spawnable = false;
        yield return new WaitForSeconds(7f);
        Instantiate(prefab, gameObject.transform);
        spawnable = true;
    }
}
