using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : KitchenUtensil
{
    [Header("Water refilling")]
    public bool IsRefilled = false;

    public GameObject Water;
    public Vector3 WaterStartingPosition, WaterEndingPosition;
    public float yDifference = 0f;
    public float WateRefillingSpeed = 0.05f;
    private void Start()
    {
        Water.SetActive(false);
        WaterEndingPosition = transform.position;
        WaterStartingPosition = WaterEndingPosition- GetComponent<Bounds>().size/2;
    }
    private new void Update()
    {
        base.TakeUtensil();
        if (IsRefilled)
            base.Update();
    }

    public IEnumerator RefillWater()
    {
        if (!Water.activeSelf)
            Water.SetActive(true);
        while (WaterStartingPosition.y < WaterEndingPosition.y)
        {
            Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, Water.transform.localPosition.y + WateRefillingSpeed, Water.transform.localPosition.z);
            WaterStartingPosition += Vector3.up * WateRefillingSpeed;
            yield return new WaitForSeconds(0.1f);
        }
        IsRefilled = true; StopAllCoroutines();
        yield return null;
    }
}
