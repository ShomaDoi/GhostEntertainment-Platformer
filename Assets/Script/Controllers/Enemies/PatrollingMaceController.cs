using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingMaceController : MonoBehaviour
{
    public GameObject player;
    public Transform[] destination;
    public bool reverse = true;
    public float speed;

    private int currentLocation = 0;
    private int destinationLength;

    private float Timer;
    private bool giveNewDestination = true;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }

    void Update()
    {
        if (new Vector2(this.transform.position.x, this.transform.position.y) == new Vector2(destination[currentLocation].position.x, destination[currentLocation].position.y))
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(destination[currentLocation].position.x, destination[currentLocation].position.y), speed * Time.deltaTime);
        }
        else
        { 
        
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
}
