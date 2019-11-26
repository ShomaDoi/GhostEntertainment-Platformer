using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Platforms")]
    public Vector2[] platformDestination;
    private int arrayLength;

    private bool platformArrayState = false;

    private float Timer;
    private float onDestination_WaitTimer = 2f;

    private bool giveNewDestination = true;
    private bool platform_NeedToWait = false;

    private Vector2 startPosition;
    private Vector2 currentPosition;
    public bool waitPlayer;

    [HideInInspector]
    public bool boxPlatforms = false;


    void Start()
    {
        if (platformDestination.Length != 0)
            platformArrayState = true;

        if (platformDestination.Length == 1 || waitPlayer)
            platform_NeedToWait = true;

        startPosition = this.transform.position;

    }

    void Update()
    {
        currentPosition = this.transform.position;
        if (platformArrayState && !boxPlatforms)
        {
            if (currentPosition == platformDestination[arrayLength] && platformDestination.Length != 1)
            {
                Timer += Time.deltaTime;

                if (Timer >= onDestination_WaitTimer && giveNewDestination)
                {
                    giveNewDestination = false;
                    NewDestination();
                }
            }
            else if (currentPosition != platformDestination[arrayLength] && !platform_NeedToWait)
            {
                transform.position = Vector2.MoveTowards(transform.position, platformDestination[arrayLength], GameManager.instance.platforms_Moving_Speed * Time.deltaTime);
            }
        }
        else if (currentPosition != startPosition)
        {
            transform.position = Vector2.MoveTowards(currentPosition, startPosition, GameManager.instance.platforms_Moving_Speed * Time.deltaTime);
            if ((platformDestination.Length == 1 && !platform_NeedToWait) || (waitPlayer && !platform_NeedToWait))
            {
                platform_NeedToWait = true;
                arrayLength = 0;
            }
        }
    }

    void NewDestination()
    {
        arrayLength++;
        if (platformDestination.Length <= arrayLength)
            arrayLength = 0;

        giveNewDestination = true;
        Timer = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = this.gameObject.transform;

            if (platform_NeedToWait)
                platform_NeedToWait = false;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}