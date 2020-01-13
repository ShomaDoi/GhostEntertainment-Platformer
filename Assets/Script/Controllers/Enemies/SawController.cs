using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public GameObject player;

    public bool isStationary;
    public float speed;

    public Transform[] destination;
    private int destinationLength;
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * -100f);

        if (!isStationary)//NEW+============================================================================
        {
            if (new Vector2(this.transform.position.x, this.transform.position.y) == new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y))
            {
                destinationLength++;
                if (destination.Length <= destinationLength)
                {
                    destinationLength = 0;
                }
            }
            else if (new Vector2(this.transform.position.x, this.transform.position.y) != new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y), speed * Time.deltaTime);
            }
            if (new Vector2(this.transform.position.x, this.transform.position.y) == new Vector2(destination[0].position.x, destination[0].position.y) ||
                new Vector2(this.transform.position.x, this.transform.position.y) == new Vector2(destination[destination.Length-1].position.x, destination[destination.Length - 1].position.y))
            {
                Flip();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.transform.position = GameManager.instance.checkpointPosition;
            GameManager.instance.SubtractLife();
        }
    }

    private void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
