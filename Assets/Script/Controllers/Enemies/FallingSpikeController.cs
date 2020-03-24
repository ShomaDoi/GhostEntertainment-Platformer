using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeController : MonoBehaviour
{
    public GameObject player, spike;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            spike.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

    }
}
