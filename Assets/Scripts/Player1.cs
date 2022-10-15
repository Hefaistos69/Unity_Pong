using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fVertical;
    private float speed = 4.0f;
    private float ScreenHeight;
    private float ScreenWidth;

    public Ball b;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        transform.position = new Vector3(-(ScreenWidth - 1f), 0.0f, 1.0f);
    }

    
    void Update()
    {
        ScreenHeight = Camera.main.orthographicSize;
        if (Input.GetKey("w"))
            fVertical = 1.0f;
        else if (Input.GetKey("s"))
            fVertical = -1.0f;
        else
            fVertical = 0.0f;

        rb.velocity = new Vector2(rb.velocity.x, fVertical * speed);

        //do not let player escape the scene

        if (transform.position.y > (ScreenHeight - 1f))
            transform.position = new Vector3(transform.position.x, (ScreenHeight - 1f), transform.position.z);
        if(transform.position.y < -(ScreenHeight - 1f))
            transform.position = new Vector3(transform.position.x, -(ScreenHeight - 1f), transform.position.z);

        if (b.Score1 >= b.GameOver || b.Score2 >= b.GameOver)
        {
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }

    }
}
