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

    public GameObject[] levelSelectPanels;
    public GameObject[] levelSelectObjects;
    public int activeLevelPanel;

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

                    for (int j = 1; j < levelSelectPanels.Length; j++)
                    {
                        levelSelectPanels[j].SetActive(false);
                    }
                    levelSelectPanels[0].SetActive(true);
                    activeLevelPanel = 0;
                    Debug.Log(activeLevelPanel);
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
                break;
            }
            else if (buttonClicked == levelSelect[1].gameObject)
            {
               activeLevelPanel++;
               changeLevelPanel();
               break;
            }
            else if (buttonClicked == levelSelect[2].gameObject)
            {
               activeLevelPanel--;
               changeLevelPanel();
               break;
            }
            else if (buttonClicked == levelSelect[i].gameObject)
            {
               SceneManager.LoadScene(i);
               break;
            }
        }
    }

    

    public void changeLevelPanel() //NEW=====================================
    {
        for (int i = 0; i < levelSelectPanels.Length; i++)
        {
            if (levelSelectPanels[i].activeInHierarchy)
            {
                levelSelectPanels[i].SetActive(false);
            }
        }
        levelSelectPanels[activeLevelPanel].SetActive(true);


        if (levelSelectPanels[0].activeInHierarchy)
        {
            levelSelectObjects[1].SetActive(false);
        }
        else if (levelSelectPanels[levelSelectPanels.Length-1].activeInHierarchy)
        {
            levelSelectObjects[0].SetActive(false);
        }
        else
        {
            levelSelectObjects[0].SetActive(true);
            levelSelectObjects[1].SetActive(true);
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


