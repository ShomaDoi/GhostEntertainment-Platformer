using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingMaceController : MonoBehaviour
{
    public GameObject player;
    public Transform[] destination;
    public float speed;

    private int destinationLength = 0;

    private float Timer;
    private float onDestination_WaitTimer = 2f;

    private bool giveNewDestination = true;


    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }

    void Update()
    {
            if (new Vector2(this.transform.position.x, this.transform.position.y) == new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y))
            {
                Timer += Time.deltaTime;

                if (Timer >= onDestination_WaitTimer && giveNewDestination)
                {
                    giveNewDestination = false;
                    NewDestination();
                }
            }
            else if (new Vector2(this.transform.position.x, this.transform.position.y) != new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(destination[destinationLength].position.x, destination[destinationLength].position.y), speed * Time.deltaTime);
            }
    }

    void NewDestination()
    {
        destinationLength++;
        if (destination.Length <= destinationLength)
            destinationLength = 0;

        giveNewDestination = true;
        Timer = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.transform.position = GameManager.instance.checkpointPosition;
            GameManager.instance.SubtractLife();
        }
        else
        {
            NewDestination();
        }
    }
}
