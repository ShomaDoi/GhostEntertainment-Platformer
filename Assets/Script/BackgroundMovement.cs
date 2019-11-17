using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

  // public float backgroundLength; ===19.5
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * 0.5f * GameManager.instance.horizontalMove, 19.5f);
        transform.position = startPosition + new Vector2(1f, 0f) * newPosition;
    }
}
