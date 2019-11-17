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

    public GameObject player;
    [Space]

    [HideInInspector]
    public Vector2 checkpointPosition;


    [Header("Coin counter")]
    public Text coinText;
    [HideInInspector]
    public int coinCount;

    [HideInInspector]
    public int lives;
    [HideInInspector]
    public bool playerDead;

    [Header("Player lives")]
    public GameObject[] hearts;

    [Header("Game over text")]
    public Text gameOverText;

    public GameObject background;

    [HideInInspector]
    public float horizontalMove = 0f;

    void Start()
    {
        instance = this;
        checkpointPosition = player.gameObject.transform.position;
        lives = hearts.Length;
        gameOverText.gameObject.SetActive(false);
        playerDead = false;
    }

    //NEW=CODE=BLOCK=================================
    public void playerLives()
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
    public void subtractLife()
    {
        Debug.Log("Life subtracted");
        if (lives == 0)
        {
            gameOver();
        }
        else
        {
            lives--;
            playerLives();
        }
    }

    public void addLife()
    {
        if(lives < hearts.Length) 
        {
            lives++;
            playerLives();
        }
    }
    public void gameOver() 
    {
        playerDead = true;
        Destroy(player);
        gameOverText.gameObject.SetActive(true);
    }
    //NEW=CODE=BLOCK=END=============================
}
