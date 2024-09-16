using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public float moveDistance = 3f;
    public float speed = 2f;
    public bool verticalMovement = true;
    private Vector2 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (verticalMovement)
        {
            float newY = Mathf.PingPong(Time.time * speed, moveDistance) + startingPosition.y;
            transform.position = new Vector2(transform.position.x, newY);
        }
        else
        {
            float newX = Mathf.PingPong(Time.time * speed, moveDistance) + startingPosition.x;
            transform.position = new Vector2(newX, transform.position.y);
        }
    }
}
