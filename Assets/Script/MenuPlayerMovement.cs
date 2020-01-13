using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerMovement : MonoBehaviour
{
    public Transform[] destination;
    private Vector2 currentPosition;

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
        
    }
    void Update()
    {
     /*   currentPosition = this.transform.position;
        if (currentPosition == new Vector2(destination[0].position.x, destination[0].position.y))
        {
            animator.SetFloat("Speed", Mathf.Abs(GameManager.instance.horizontalMove));
        }*/
    }

    void FixedUpdate()
    {
            controller.Move(GameManager.instance.horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
