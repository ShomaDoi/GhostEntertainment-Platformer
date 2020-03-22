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

    [Header("Level selection")]
    public GameObject[] levelSelectButtonsObject;
    public GameObject[] levelSelectButtons;
    public GameObject[] levelSelectPanels;
    public GameObject[] levelSelectObjects;
    public GameObject[] levelDoors;
    public int activeLevelPanel;
    [Space]

    [HideInInspector]
    public int levelToEnter;

    [Header("Main menu")]
    public Button[] menuButtons;
    [Space]

    [Header("Settings")]
    public Button[] settingsButtons;
    public float masterSliderValue;
    public float musicSliderValue;
    public Text[] volumeLevels;
    public GameObject[] settingsObjects;
    [Space]

    [Header("Shop")]
    public Button[] shopButtons;
    public GameObject[] shopObjects;
    public GameObject shopConfirmation;
    public Button[] confirmationButtons;



    public void Start()
    {
        openPanel[0].SetActive(true);
        openPanel[1].SetActive(false);
        openPanel[2].SetActive(false);
    }

    public void Menu()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < menuButtons.Length; i++)
        {
            if (buttonClicked == menuButtons[i].gameObject)
            {
                switch (i) {

                    case 0:
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
                            break;
                        }
                    case 1:
                        {
                            for (int j = 0; j < openPanel.Length; j++)
                            {
                                openPanel[j].SetActive(false);
                            }
                            openPanel[1].SetActive(true);
                            break;
                        }
                    case 2:
                        {
                            for (int j = 0; j < openPanel.Length; j++)
                            {
                                openPanel[j].SetActive(false);
                            }
                            openPanel[3].SetActive(true);
                            break;
                        }
                    case 3:
                        {
                            Application.Quit();
                            Debug.Log("ExitGame");
                            break;
                        }
                }
            }
        }
    }

    public void SelectLevel()//NEW==========================================================
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < levelSelectButtons.Length; i++)
        {
            if (buttonClicked == levelSelectButtons[0].gameObject)
            {
                SceneManager.LoadScene(levelToEnter);
                break;
            }
        }
    }

    

    public void ChangeLevelPanel() //NEW=====================================
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
        for (int i = 0; i < settingsButtons.Length; i++)
        {
            if (buttonClicked == settingsButtons[i].gameObject)
            {
                switch (i)
                {
                    case 0:
                        {
                            openPanel[1].SetActive(false);
                            openPanel[0].SetActive(true);
                            break;
                        }
                    case 1:
                        {
                            Debug.Log("reMOVE ADS");
                            //openPanel[1].SetActive(false);
                            //openPanel[3].SetActive(true);
                            settingsObjects[0].SetActive(false);
                            settingsObjects[1].SetActive(true);
                            break;
                        }
                    case 2:
                        {
                            settingsObjects[1].SetActive(false);
                            settingsObjects[2].SetActive(true);
                            Debug.Log("Ads disabled");
                            break;
                        }
                    case 3:
                        {
                            settingsObjects[2].SetActive(false);
                            settingsObjects[1].SetActive(true);
                            Debug.Log("Ads enabled");
                            break;
                        }
                }
            }
        }
        volumeLevels[0].text = masterSliderValue.ToString();
        volumeLevels[1].text = musicSliderValue.ToString();
    }

    public void Shop()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < shopButtons.Length; i++)
            if (buttonClicked == shopButtons[i].gameObject)
            {
                {
                    switch (i)
                    {
                        case 0:
                            {
                                openPanel[3].SetActive(false);
                                openPanel[0].SetActive(true);
                                break;
                            }
                        case 1:
                            {
                                openPanel[3].SetActive(false);
                                shopConfirmation.gameObject.SetActive(true);
                                break;
                            }
                    }
                }
        }
    }

    public void ShopConfirmation()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < confirmationButtons.Length; i++)
        {
            if (buttonClicked == confirmationButtons[i].gameObject)
            {
                if (i == 0)
                {
                    shopButtons[1].gameObject.SetActive(false);
                    settingsButtons[1].gameObject.SetActive(false);
                    settingsButtons[2].gameObject.SetActive(true);
                    Debug.Log("Remove ads purchased");
                    break;
                }
                else if (i == 1)
                {
                    break;
                }
            }
        }
        shopConfirmation.SetActive(false);
        openPanel[3].SetActive(true);
    }
}


