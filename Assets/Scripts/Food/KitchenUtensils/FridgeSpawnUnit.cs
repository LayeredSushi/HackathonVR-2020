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
        FoodItem foodItem = Instantiate(prefab, transform.position /*+ new Vector3(0, -0.3f, 0)*/, transform.rotation);
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
        FoodItem foodItem = Instantiate(prefab, transform.position/* + new Vector3(0,-0.3f,0)*/, transform.rotation);
        foodItem.transform.position = transform.position;
        spawnable = true;
    }
}
