using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public GameObject player;
    public GameObject[] hearts;
    public int maxPlayerLives;


    [HideInInspector]
    public int lives;
    [HideInInspector]
    public bool playerDead;

    [Space]

    [HideInInspector]
    public Vector2 checkpointPosition;


    [Header("Coin counter")]
    public Text coinText;
    [HideInInspector]
    public int coinCount;
    

    [Header("Game over text")]
    public Text gameOverText;

    public GameObject background;

    [HideInInspector]
    public float horizontalMove = 0f;


    void Start()
    {
        instance = this;
        checkpointPosition = player.gameObject.transform.position;

        lives = maxPlayerLives;

        gameOverText.gameObject.SetActive(false);
        playerDead = false;
    }


    public void PlayerLife()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
        for (int i = 0; i < lives; i++)
        {
            hearts[i].SetActive(true);
        }
    }


    public void SubtractLife()
    {
        lives--;
        PlayerLife();

        if (lives <= 0)
        {
            GameOver();
        }
    }


    public void AddLife()
    {
        if(lives < maxPlayerLives) 
        {
            lives++;
            PlayerLife();
        }
    }


    public void GameOver() 
    {
        playerDead = true;
        Destroy(player);
        gameOverText.gameObject.SetActive(true);
    }
}
