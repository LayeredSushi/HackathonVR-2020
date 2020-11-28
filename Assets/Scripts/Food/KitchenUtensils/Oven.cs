using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{

   public List<KitchenUtensil> utensils;
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<KitchenUtensil>())
            AddUtensil(other.gameObject.GetComponent<KitchenUtensil>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<KitchenUtensil>())
            RemoveUtensil(other.gameObject.GetComponent<KitchenUtensil>());
    }

    private void OnTriggerStay(Collider other)
    {

        foreach (var utensil in utensils)
        {
            if (utensil.temperature < 300)
            {
                utensil.temperature += 0.05f;
            }
        }



    }
    public void AddUtensil(KitchenUtensil utensil)
    {
        Debug.Log("Tried to add");
        if (utensils != null && utensil!=null && !utensils.Contains(utensil))
        {
            utensils.Add(utensil);
        }
    }
    public void RemoveUtensil(KitchenUtensil utensil)
    {
        Debug.Log("Tried to remove");
        if (utensils != null && utensil != null && utensils.Contains(utensil))
        {
            utensils.Remove(utensil);
        }
    }
}
