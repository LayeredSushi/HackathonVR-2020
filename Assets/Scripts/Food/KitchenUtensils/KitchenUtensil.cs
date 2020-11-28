using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenUtensil : Grabbable
{
    public float temperature;
    public FoodItem foodItem;
    public float temperatureChangeRate = 0.05f;

    private void Update()

    {
        if (foodItem)
            if (foodItem.temperature < temperature)
                foodItem.temperature = Mathf.Clamp(foodItem.temperature + temperatureChangeRate, 0, temperature);
            else if (foodItem.temperature > temperature)
                foodItem.temperature = Mathf.Clamp(foodItem.temperature - temperatureChangeRate, 0, temperature);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType().IsSubclassOf(typeof(FoodItem)))
        {
            foodItem = other.gameObject.GetComponent<FoodItem>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetType().IsSubclassOf(typeof(FoodItem)))
        {
            foodItem = null;
        }
    }
}
