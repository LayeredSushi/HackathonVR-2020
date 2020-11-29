using TMPro;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public TMP_Text instructionsText;
    private static Instructions instance;
    private readonly CookingSteps[] steps = {
        new CookingSteps{ Time = 3f, Description="1. Nehmen Sie die Wurst und die Kartoffeln aus dem Kühlschrank", IsCompleted= false },
        new CookingSteps{ Time = 3f, Description="2. Finden Sie das Messer im Nachttisch und schälen Sie die Kartoffeln", IsCompleted= false },
        new CookingSteps{ Time = 4f, Description="3. Wasser in einen Topf geben und auf den Herd stellen.", IsCompleted= false },
        new CookingSteps{ Time = 5f, Description="4.Die Kartoffeln in den Topf geben fünf.", IsCompleted=false},
        new CookingSteps{ Time = 2f, Description="5.Schalten Sie den Herd ein und stellen Sie die Pfanne darauf", IsCompleted=false},
        new CookingSteps{ Time = 3f, Description="6.Legen Sie die Wurst in die Pfanne", IsCompleted=false},
        new CookingSteps{ Time = 4f, Description="7.Warten Sie bis zum Kochen, nehmen Sie die Kartoffeln aus der Pfanne und die Wurst aus der Pfanne auf einen Teller", IsCompleted=false},
    };

    public int CurrentTask = 0;
    private bool AreTasksCompleted = false;

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

    public void SetTaskCompleted()
    {
        steps[CurrentTask].IsCompleted = true;
        SetCurrentTaskIndex();
    }

    public void SetCurrentTaskIndex()
    {
        if(CurrentTask == steps.Length-1) {
            Debug.Log("All tasks are completed!");
            AreTasksCompleted = true;
        } else
        {
            CurrentTask++;
            SetInstruction(steps[CurrentTask].Description);
        }
    }

    public bool AreAllTasksCompleted()
    {
        return AreTasksCompleted;
    }

    public int GetCurrentTask()
    {
        return CurrentTask;
    }

    public float GetCurrentTaskTime()
    {
        return steps[CurrentTask].Time;
    }

    public static Instructions GetInstance()
    {
        return instance;
    }

    public void SetInstruction(string text)
    {
        instructionsText.SetText(text);
    }
}
