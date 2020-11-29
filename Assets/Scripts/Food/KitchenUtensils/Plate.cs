using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject sausageOnPlatePrefab;
    private void OnTriggerEnter(Collider other)
    {
        FoodItem foodItem = other.gameObject.GetComponent<FoodItem>();
        if (foodItem)
        {
            if(foodItem.isFinished)
            {
                if(foodItem.GetType() == typeof(Sausage))
                {
                    Destroy(foodItem.gameObject);
                    GameObject newPlate = Instantiate(sausageOnPlatePrefab, transform.position + new Vector3(0,0.3f,0), transform.rotation);
                    newPlate.transform.SetParent(null);
                    Destroy(gameObject);
                }
            }
        }
    }
}
