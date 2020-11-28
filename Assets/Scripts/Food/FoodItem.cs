using UnityEngine;

public abstract class FoodItem : Grabbable
{
    public float currentTemperature;
    public float startingSpoilTemperature = 180f;
    public float minimumCookingTemperature = 120f;
    public float cookingTime = 20f;
    public float itemHp = 100f;
    public bool isSpoiled = false;
    public bool isFinished = false;
    public Mesh SpoiledMesh;

    private void Update()
    {
        if (currentTemperature >= minimumCookingTemperature && currentTemperature < startingSpoilTemperature && !isSpoiled)
        { // food is cooked under normal temperature and is not spoiled
            cookingTime = Mathf.Clamp(cookingTime -= Time.deltaTime, 0, cookingTime);
            //Timer.GetInstance().StartTimer(cookingTime);
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
            DecreaseItemHp(minimumCookingTemperature / 100f);

        if (itemHp <= 0)
        {
            isSpoiled = true;
            isFinished = false;
            Spoil();
        }
    }

    private void Spoil()
    {
        GetComponent<MeshFilter>().mesh = SpoiledMesh;
    }
    public void DecreaseItemHp(float value)
    {
        itemHp = Mathf.Clamp(itemHp -= value, 0, itemHp);
    }
}
