using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    public bool isGrounded = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isGrounded == false)
        {
            CharacterController2D.instance.OnLandEvent.Invoke();
            isGrounded = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
