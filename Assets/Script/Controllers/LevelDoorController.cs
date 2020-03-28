using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class LevelDoorController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MenuManager.instance.levelSelectButtonsObject[0].gameObject.SetActive(true);
            for (int i = 0; i < MenuManager.instance.levelDoors.Length; i++)
            {
                if (MenuManager.instance.levelDoors[i] == this && MenuManager.instance.levelToEnter != i + 1)
                {
                    MenuManager.instance.levelToEnter = i + 1;
                    Debug.Log("MenuManager.instance.levelToEnter");
                    break;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MenuManager.instance.levelSelectButtonsObject[0].gameObject.SetActive(false);
        }
    }
}

