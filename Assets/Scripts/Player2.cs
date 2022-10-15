using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fVertical = 0.0f;
    private static bool isBot = false;
    private float ScreenHeight;
    private float ScreenWidth;

    public float speed = 4.0f;
    public Ball b;
    public Rigidbody2D ball;

    public void IsPlayer()
    {
        isBot = false;
    }

    public void IsBot()
    {
        isBot = true;
    }

    public void Difficulty(int a)
    {
        if (a == 0)
            speed = 5f;
        if (a == 1)
            speed = 8f;
        if (a == 2)
            speed = 10f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        transform.position = new Vector3(ScreenWidth - 1f, 0.0f, 1.0f);

    }

    void Update()
    {
        ScreenHeight = Camera.main.orthographicSize;
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        //verify if is a bot
        if (isBot)
        {
            //verify if the ball is int the play screen
            if (ball.transform.position.y > -ScreenHeight && ball.transform.position.y < ScreenHeight && ball.transform.position.x > -ScreenWidth && ball.transform.position.x < ScreenWidth)
            {
                //verify if the ball moves
                if (ball.velocity != Vector2.zero)
                {
                    //P2 goes after the ball
                    if (ball.transform.position.y > transform.position.y)
                        fVertical = 1.0f;
                    else
                        fVertical = -1.0f;
                }
                else
                    fVertical = 0.0f;

                //update the velocity
                rb.velocity = new Vector2(rb.velocity.x, fVertical * speed);
                
                
                //do not let player escape the scene
                if (transform.position.y > (ScreenHeight - 1f))
                    transform.position = new Vector3(transform.position.x, (ScreenHeight - 1f), transform.position.z);
                if (transform.position.y < -(ScreenHeight - 1f))
                    transform.position = new Vector3(transform.position.x, -(ScreenHeight - 1f), transform.position.z);

            }
            else
            {
                //going in the centre of the screen if the ball is not in the play screen
                if (transform.position.y > 0)
                    fVertical = -0.5f;
                if (transform.position.y < 0)
                    fVertical = 0.5f;

                if (transform.position.y < 0.1f && transform.position.y > -0.1f)
                {
                    transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
                    rb.velocity = Vector2.zero;
                }
                else
                    rb.velocity = new Vector2(rb.velocity.x, fVertical * speed);

            }
        }
        else
        {
            //managing the input
            if (Input.GetKey("up"))
                fVertical = 1.0f;
            else if (Input.GetKey("down"))
                fVertical = -1.0f;
            else
                fVertical = 0.0f;
            //update the velocity
            rb.velocity = new Vector2(rb.velocity.x, speed * fVertical);

            //keep the player into the play screen
            if (transform.position.y > (ScreenHeight - 1f))
                transform.position = new Vector3(transform.position.x, (ScreenHeight - 1f), transform.position.z);
            if (transform.position.y < -(ScreenHeight - 1f))
                transform.position = new Vector3(transform.position.x, -(ScreenHeight - 1f), transform.position.z);
        }
        //verify if some one has won
        if(b.Score1 >= b.GameOver || b.Score2 >= b.GameOver)
        {
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
    }
}
