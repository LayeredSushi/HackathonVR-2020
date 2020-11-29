using UnityEngine;

public abstract class KitchenUtensil : Grabbable
{
    public float temperature;
    public FoodItem foodItem;
    public float temperatureChangeRate = 0.05f;
    public AudioSource audioSource;
    public string soundName;

    private void Start()
    {
        if(audioSource != null && soundName != null)
        {
            audioSource.clip = Resources.Load("Sounds/" + soundName) as AudioClip;
        }
    }

    public void Update()
    {
        if (foodItem)
            if (foodItem.currentTemperature < temperature)
                foodItem.currentTemperature = Mathf.Clamp(foodItem.currentTemperature + temperatureChangeRate, 0, temperature);
            else if (foodItem.currentTemperature > temperature)
                foodItem.currentTemperature = Mathf.Clamp(foodItem.currentTemperature - temperatureChangeRate, 0, temperature);
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
            if(audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
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

            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        Debug.Log(other + "Exit");
    }
}
