using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [Space]

    [Header("Active panel")]
    public GameObject[] openPanel;

    [Space]

    [Header("Buttons")]
    public Button[] menu;
    public Button closeSettings;
    public float masterSliderValue;
    public float musicSliderValue;
    public Text[] volumeLevels;


    public void Menu()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < menu.Length; i++)
        {
            if (buttonClicked == menu[i].gameObject)
            {
                if (i == 0)
                {
                    SceneManager.LoadScene(1);
                }
                else if (i == 1)
                {
                    openPanel[0].SetActive(true);
                }
                else
                {
                    Application.Quit();
                    Debug.Log("ExitGame");
                }
            }
        }
    }


    public void Settings()
    {
        masterSliderValue = GameObject.Find("MasterSound").GetComponent<Slider>().value;
        musicSliderValue = GameObject.Find("MusicSound").GetComponent<Slider>().value;

        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (buttonClicked == closeSettings.gameObject)
        {
            openPanel[0].SetActive(false);
        }

        volumeLevels[0].text = masterSliderValue.ToString();
        volumeLevels[1].text = musicSliderValue.ToString();
        Debug.Log(masterSliderValue);
        Debug.Log(musicSliderValue);
    }
}


