using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Controller script")]
    public CharacterController2D controller;
    [Space]

    [Header("Player animator")]
    public Animator animator;
    [Space]

    [Header("Running speed")]
    public float runSpeed = 40f;
    [Space]

    float horizontalMove = 0f;
    bool jump = false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && CharacterController2D.instance.jumpNumber <= CharacterController2D.instance.maxJumpNumber)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        CharacterController2D.instance.jumpNumber = 0;
    }
}
