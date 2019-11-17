using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour{

    public GameObject player;
     void Start()
     {
        /*Collider2D toIgnore = player.GetComponents<Collider2D>()[1];
        Physics2D.IgnoreCollision(toIgnore, this.GetComponent<Collider2D>());*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & this.GetComponent<Collider2D>().bounds.Intersects(player.GetComponents<Collider2D>()[0].bounds))
        {
            Debug.Log("Fall");
                GameManager.instance.player.transform.position = GameManager.instance.checkpointPosition;
                GameManager.instance.subtractLife();
        }
    }
}
