using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Cinemachine;

public class LevelController : MonoBehaviour
{
    private float minPos;
    public float maxPos;
    public Camera cam;
    public CinemachineVirtualCamera vcam;
    public GameObject player;

    void Start()
    {
        minPos = player.transform.position.x;
    }

    void Update()
    {
        if (vcam.transform.position.x > maxPos)
        {
            vcam.transform.position = new Vector2(maxPos, vcam.transform.position.y);
            cam.transform.position = new Vector2(maxPos, cam.transform.position.y);
        }
        if (vcam.transform.position.x < minPos)
        {
            vcam.transform.position = new Vector2(minPos, vcam.transform.position.y);
            cam.transform.position = new Vector2(minPos, cam.transform.position.y);
        }

    }
}
