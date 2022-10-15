using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BallCollider : MonoBehaviour
{
    public Ball ball;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        float angle = ball.Angle;
        Rigidbody2D rb = ball.Rb;

        Instantiate(ball.BounceEffect, rb.transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(4f, 1f, 0.2f, 0.2f);
        ball.BounceSound.Play();


        if (rb.velocity.x > 0)
            if (rb.velocity.y > 0)
                angle += Mathf.PI / 2;
            else
                angle -= Mathf.PI / 2;
        if (rb.velocity.x < 0)
            if (rb.velocity.y > 0)
                angle -= Mathf.PI / 2;
            else
                angle += Mathf.PI / 2;
        ball.Angle = angle;
    }
}
