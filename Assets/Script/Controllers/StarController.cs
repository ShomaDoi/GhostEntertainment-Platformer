using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public Animator animator;
    private bool alreadyOpen = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !alreadyOpen)
                GameManager.instance.starCollected = true;
                alreadyOpen = true;
                animator.SetBool("isOpen", true);                
    }
}
