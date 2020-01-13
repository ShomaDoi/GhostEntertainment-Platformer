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
    public GameObject backgroundDetails;

    [Space]

    [Header("Buttons")]
    public Button[] menu;
    public Button[] levelSelect;
    public Button closeSettings;
    public float masterSliderValue;
    public float musicSliderValue;
    public Text[] volumeLevels;



    public void Start()
    {
        openPanel[0].SetActive(true);
        openPanel[1].SetActive(false);
        openPanel[2].SetActive(false);
    }

    public void Menu()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < menu.Length; i++)
        {
            if (buttonClicked == menu[i].gameObject)
            {
                if (i == 0)
                {
                    for (int j = 0; j < openPanel.Length; j++)
                    {
                        openPanel[j].SetActive(false);
                    }
                    openPanel[2].SetActive(true);
                }
                else if (i == 1)
                {
                    for(int j = 0; j < openPanel.Length; j++)
                    {
                        openPanel[j].SetActive(false);
                    }
                    openPanel[1].SetActive(true);
                }
                else
                {
                    Application.Quit();
                    Debug.Log("ExitGame");
                }
            }
        }
    }

    public void SelectLevel()//NEW==========================================================
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < levelSelect.Length; i++)
        {
            if (buttonClicked == levelSelect[0].gameObject)
            {
                openPanel[2].SetActive(false);
                openPanel[0].SetActive(true);
            }
            else if (buttonClicked == levelSelect[i].gameObject)
            {
                SceneManager.LoadScene(i);              
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
            openPanel[1].SetActive(false);
            openPanel[0].SetActive(true);

        }
        volumeLevels[0].text = masterSliderValue.ToString();
        volumeLevels[1].text = musicSliderValue.ToString();
    }
}


