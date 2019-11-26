using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.coinCount++;
            //Debug.Log("Coins: " + GameManager.instance.coinCount);
            GameManager.instance.coinText.text = GameManager.instance.coinCount.ToString();
            Destroy(gameObject);
        }
    }
 }
