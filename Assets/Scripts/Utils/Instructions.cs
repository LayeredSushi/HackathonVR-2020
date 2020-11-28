using TMPro;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public TMP_Text instructionsText;
    private static Instructions instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<Instructions>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Instructions GetInstance()
    {
        return instance;
    }

    public void setInstruction(string text)
    {
        instructionsText.SetText(text);
    }
}
