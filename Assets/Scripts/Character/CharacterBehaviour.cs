using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    Animator animator;
    public string animatorTrigger = "launchAnimation";

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Equals("HeadCollider")) {
            animator.SetTrigger(animatorTrigger);
        }
    }
}
