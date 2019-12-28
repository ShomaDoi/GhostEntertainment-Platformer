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
    [HideInInspector]
    public bool isPaused;

    [Space]

    [HideInInspector]
    public Vector2 checkpointPosition;


    [Header("Coin counter")]
    public Text coinText;
    [HideInInspector]
    public int coinCount;


    [Header("Ingame UI elements")] //NEW======================
    public GameObject[] inGameMenus;
    public Button[] buttons;
    public GameObject gameUI;
    [Space]


    public GameObject background;

    [HideInInspector]
    public float horizontalMove = 0f;

    [Header("Platforms")]
    public float platforms_Moving_Speed;
    public bool platformsTo_StartPosition = false;

    void Start()
    {
        instance = this;
        checkpointPosition = player.gameObject.transform.position;

        lives = maxPlayerLives;

        for (int i = 0; i < inGameMenus.Length; i++) //NEW======================
        {
            inGameMenus[i].SetActive(false);
        }
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
        if (lives < maxPlayerLives)
        {
            lives++;
            PlayerLife();
        }
    }


    public void GameOver()
    {
        playerDead = true;
        inGameMenus[0].gameObject.SetActive(true);
        Destroy(player);

    }


    public void ButtonClick()//NEW======================
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
                            SceneManager.LoadScene(0);
                            break;
                        }

                    case 1:
                        {
                            SceneManager.LoadScene(0);
                            break;
                        }
                    case 2:
                        {
                            Time.timeScale = 0;
                            inGameMenus[1].gameObject.SetActive(true);
                            gameUI.gameObject.SetActive(false);
                            break;
                        }
                    case 3:
                        {
                            SceneManager.LoadScene(0);
                            break;
                        }
                    case 4:
                        {
                            Time.timeScale = 1;
                            inGameMenus[1].gameObject.SetActive(false);
                            gameUI.gameObject.SetActive(true);
                            break;
                        }
                }
            }
        }
    }
}
