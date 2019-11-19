using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerMovement.instace.legCollider);
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
