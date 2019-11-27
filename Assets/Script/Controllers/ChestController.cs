using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    private bool alreadyOpen = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !alreadyOpen)
            if (GameManager.instance.lives < GameManager.instance.maxPlayerLives)
            {
                alreadyOpen = true;
                animator.SetBool("isOpen", true);
                GameManager.instance.AddLife();
            }

    }
}
