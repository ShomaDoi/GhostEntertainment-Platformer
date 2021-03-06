﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponents<Collider2D>()[0]);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.transform.position = GameManager.instance.checkpointPosition;
            GameManager.instance.SubtractLife();
        }
        if (collision.gameObject.CompareTag("Pit"))
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
