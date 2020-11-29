using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject emptyPlate;
    public GameObject sausageOnPlatePrefab;
    public GameObject potatoOnPlatePrefab;
    public GameObject sausageAndPotatoOnPlateprefab;

    public bool isSausageCreated = false;
    public bool isPotatoCreated = false;
    private void OnTriggerEnter(Collider other)
    {
        FoodItem foodItem = other.gameObject.GetComponent<FoodItem>();
        if (foodItem)
        {
            if (foodItem.isFinished)
            {
                if (foodItem.GetType() == typeof(Sausage) && !isSausageCreated)
                {
                    InstantiateFoodOnThePlate(foodItem, sausageOnPlatePrefab);
                    isSausageCreated = true;
                }
                if (foodItem.GetType() == typeof(Potato) && isPotatoCreated)
                {
                    InstantiateFoodOnThePlate(foodItem, potatoOnPlatePrefab);
                    isPotatoCreated = true;
                }
            }
        }
        if (isSausageCreated && isPotatoCreated)
        {
            InstantiateFoodOnThePlate(null, sausageAndPotatoOnPlateprefab);
        }
    }

    private void InstantiateFoodOnThePlate(FoodItem foodItem, GameObject foodType)
    {
        Destroy(foodItem.gameObject);
        //GameObject newPlate = Instantiate(foodType, transform.position + new Vector3(0, 0.3f, 0), transform.rotation);
        DisableAll();
        foodType.SetActive(true);
        //newPlate.transform.SetParent(null);
        //Destroy(gameObject);
    }
    private void DisableAll()
    {
        emptyPlate.SetActive(false);
        sausageOnPlatePrefab.SetActive(false);
        //potatoOnPlatePrefab.SetActive(false);
        sausageAndPotatoOnPlateprefab.SetActive(false);
    }
}
