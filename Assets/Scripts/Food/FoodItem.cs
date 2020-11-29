using System.Collections;
using UnityEngine;

public abstract class FoodItem : Grabbable
{
    public float currentTemperature;
    public float startingSpoilTemperature = 180f;
    public float minimumCookingTemperature = 120f;
    public float temperatureCoolOffRate = 1f;
    public float cookingTime = 20f;
    public float itemHp = 100f;

    public bool isSpoiled = false;
    public bool IsProcessed = false;
    public bool isFinished = false;

    public Material SpoiledMaterial; // overcooked
    public Material ProcessedFood;//knifed
    public Material CookedFood;//cooked

    public KitchenUtensil AppliedUtensil;

    public virtual void Cook()
    {
        if (currentTemperature >= minimumCookingTemperature && currentTemperature < startingSpoilTemperature && !isSpoiled)
        { // food is cooked under normal temperature and is not spoiled
            cookingTime = Mathf.Clamp(cookingTime -= Time.deltaTime, 0, cookingTime);
            Timer.GetInstance().StartTimer(cookingTime);
        }
        else if (currentTemperature > startingSpoilTemperature)
        {
            DecreaseItemHp((currentTemperature - startingSpoilTemperature) / 100f);

        }
        if (cookingTime <= 0f && !isSpoiled)
        {
            isFinished = true;
        }
        if (isFinished)
        {
            DecreaseItemHp(minimumCookingTemperature / 200f);
            TurnToCookedFood();
        }

        if (itemHp <= 0)
        {
            isSpoiled = true;
            isFinished = false;
            Spoil();
        }
    }

    private void Spoil()
    {
        GetComponent<Renderer>().material = SpoiledMaterial;
    }
    public void DecreaseItemHp(float value)
    {
        itemHp = Mathf.Clamp(itemHp -= value, 0, itemHp);
    }

    public void ProcessFood()
    {
        if (ProcessedFood != null)
            GetComponent<Renderer>().material = ProcessedFood;
    }

    public void TurnToCookedFood()
    {
        GetComponent<Renderer>().material = CookedFood;
    }

    public IEnumerator CoolOff()
    {
        currentTemperature = Mathf.Clamp(currentTemperature - temperatureCoolOffRate, 0, currentTemperature);
        yield return new WaitForSeconds(0.1f);
    }
}
