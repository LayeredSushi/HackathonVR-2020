using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HighlightChanger))]
public class OpeningFurniture : Interactable
{
    bool isOpen = false;
    HighlightChanger highlightChanger;
    public Animator animator;

    public string firstState;
    public string secondState;

    private void Start()
    {
        highlightChanger = GetComponent<HighlightChanger>();
    }

    public override void OnInteraction(HandManager handManager, PointerEventArgs args)
    {
        //if (AudioManager.isPlaying)
        //    return;

        if (isOpen)
            animator.Play(firstState);
        else
            animator.Play(secondState);

        isOpen = !isOpen;
    }

    public override void OnPointerEnter(HandManager handManager, PointerEventArgs args)
    {
        highlightChanger.DoHighlight();
    }

    public override void OnPointerExit(HandManager handManager, PointerEventArgs args)
    {
        highlightChanger.MakeDefaultState();
    }
}
