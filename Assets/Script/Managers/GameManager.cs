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


    [Header("Game over screen")]
    public GameObject gameOverMenu;
    public Text gameOverText;
    public Button[] buttons;

    public GameObject background;

    [HideInInspector]
    public float horizontalMove = 0f;

    public float platforms_Moving_Speed;
    public bool platformsTo_StartPosition = false;

    void Start()
    {
        instance = this;
        checkpointPosition = player.gameObject.transform.position;

        lives = maxPlayerLives;

        gameOverMenu.SetActive(false);
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
        gameOverMenu.gameObject.SetActive(true);
        Destroy(player);
        
    }


    public void ButtonClick()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttonClicked == buttons[i].gameObject)
            {
                switch (i)
                {
                    case 0:
                        {
                            Debug.LogWarning("Non line code here !");
                            break;
                        }

                    case 1:
                        {
                            SceneManager.LoadScene(0);
                            break;
                        }
                }
            }
        }
    }
}
