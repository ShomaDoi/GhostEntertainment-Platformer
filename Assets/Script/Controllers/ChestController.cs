using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    public bool alreadyOpen = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !alreadyOpen)
            if (GameManager.instance.lives < GameManager.instance.hearts.Length)
            {
                {
                    animator.SetBool("isOpen", true);
                    alreadyOpen = true;
                    GameManager.instance.addLife();
                }
            }

    }
}
