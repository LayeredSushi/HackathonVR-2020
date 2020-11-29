﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenUtensil : Grabbable
{
    public float temperature;
    public FoodItem foodItem;
    public float temperatureChangeRate = 0.05f;

    public new  void Update()
    {
       // base.Update();
        if (foodItem)
            if (foodItem.currentTemperature < temperature)
                foodItem.currentTemperature = Mathf.Clamp(foodItem.currentTemperature + temperatureChangeRate, 0, temperature);
            else if (foodItem.currentTemperature > temperature)
                foodItem.currentTemperature = Mathf.Clamp(foodItem.currentTemperature - temperatureChangeRate, 0, temperature);
    }
    public void TakeUtensil()
    {
        base.Update();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<FoodItem>() != null)
        {
            FoodItem item = other.gameObject.GetComponent<FoodItem>();
            if (item.AppliedUtensil == this)
            {

                foodItem = item;
                item.StopAllCoroutines();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<FoodItem>())
        {
            if (foodItem != null)
                StartCoroutine(foodItem.CoolOff());
            foodItem = null;
        }

        Debug.Log(other + "Exit");
    }
}
