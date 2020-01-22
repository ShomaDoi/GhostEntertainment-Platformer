using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    public static PlayerGrounded instance;

    public bool isGrounded = true;


    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGrounded == false && collision.CompareTag("Ground"))
        {
            PlayerMovement.instace.OnLanding();
            isGrounded = true;
        }
    }
}