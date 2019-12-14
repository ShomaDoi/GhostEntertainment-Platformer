using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instace;

    [Header("Controller script")]
    public CharacterController2D controller;
    [Space]

    [Header("Player animator")]
    public Animator animator;
    [Space]

    [Header("Running speed")]
    public float runSpeed = 40f;
    [Space]

    [Header("Player Colliders")]
    public Collider2D legCollider;

    //float horizontalMove = 0f;
    [HideInInspector]
    public bool jump = false;


    void Start()
    {
        instace = this;
    }


    void Update()
    {
        if (!GameManager.instance.playerDead)//NEW========================================
        {
            GameManager.instance.horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(GameManager.instance.horizontalMove));

            if (Input.GetButtonDown("Jump") && CharacterController2D.instance.jumpNumber <= CharacterController2D.instance.maxJumpNumber)
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }


    void FixedUpdate()
    {
        if (!GameManager.instance.playerDead)
        {
            controller.Move(GameManager.instance.horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
        }
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        CharacterController2D.instance.jumpNumber = 0;
    }
}
