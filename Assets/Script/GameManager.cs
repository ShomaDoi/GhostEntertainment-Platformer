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


    void Start()
    {
        instance = this;
        checkpointPosition = player.gameObject.transform.position;
    }
}
