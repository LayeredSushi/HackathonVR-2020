using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public abstract void OnPointerEnter(HandManager handManager, PointerEventArgs args);
    public abstract void OnPointerExit(HandManager handManager, PointerEventArgs args);
    public abstract void OnInteraction(HandManager handManager, PointerEventArgs args);
}
