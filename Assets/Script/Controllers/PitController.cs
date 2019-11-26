using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerMovement.instace.legCollider);//ovo je bacalo null exception pa sam promenio u red ispod
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.transform.position = GameManager.instance.checkpointPosition;
            GameManager.instance.SubtractLife();
        }
    }
}
