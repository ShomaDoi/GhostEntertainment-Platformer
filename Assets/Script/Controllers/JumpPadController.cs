using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    public GameObject player;
    public float jumpForce = 300f;
    private float timer;
    private bool shrink = false;
    private bool expand = false;
    private int changingShape;
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[1]);
    }

    void Update() 
    {
        Vector2 temp = transform.localScale;
        if (shrink)
        {
            this.transform.localScale = new Vector2(1f, 0.5f);
            this.transform.Translate(new Vector2(0, -0.2f) * 3 * Time.deltaTime);
            changingShape++;
            transform.localScale = temp;
            if (changingShape == 5)
            {
                shrink = false;
                expand = true;
                changingShape = 0;
            }
        }
        if (expand)
        {
            this.transform.localScale = new Vector2(1f, 1f);
            this.transform.Translate(new Vector2(0, 0.2f) * 3 * Time.deltaTime);
            changingShape++;
            if (changingShape == 5)
            {;
                expand = false;
                changingShape = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            shrink = true;
        }
    }



}
