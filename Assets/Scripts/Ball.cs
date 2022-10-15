using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using EZCameraShake;

public class Ball : MonoBehaviour
{
    private float magnitude = 4f, roughness = 1f, fadeInTime = 0.2f, fadeOutTime = 0.2f;

    private float ScreenWidth;
    private float ScreenHeight;
    private Rigidbody2D rb;
    private float angle;
    private int score1;
    private int score2;
    private float CTime = 3.0f;
    private int gameOver = 7;

    public float CurrentTime;
    public Transform player1, player2;
    public int Score1 { get => score1; set => score1 = value; }
    public int Score2 { get => score2; set => score2 = value; }
    public int GameOver { get => gameOver; }

    public GameObject BounceEffect;
    public GameObject PointEffect;
    public AudioSource BounceSound;
    public AudioSource PointSound;
    public GameObject WinnerMenu;
    public GameObject Game;
    public TextMeshProUGUI CDText;
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public TextMeshProUGUI Winner;
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
    }

    public float Angle 
    {
        get
        {
            return angle;
        }
        set
        {
            angle = value;
        }
    }

    private float inputSpeed = 15;
    private float speed;

    void Start()
    {
        score1 = 0;
        score2 = 0;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, 100.0f, transform.position.z);
        CurrentTime = CTime;
        Invoke("Restart", 2);
    }

    void Update()
    {
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        ScreenHeight = Camera.main.orthographicSize;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
        
        if (CurrentTime < 1)
        {
            CDText.gameObject.SetActive(false);

            if (transform.position.x < -ScreenWidth || transform.position.x > ScreenWidth)
            {
                Instantiate(PointEffect, transform.position, Quaternion.identity);
                CameraShaker.Instance.ShakeOnce(12f, 4f, 1.2f, 1.2f);
                PointSound.Play();

                if (transform.position.x < -ScreenWidth)
                    score2++;
                else
                    score1++;
                transform.position = new Vector3(100.0f, 100.0f, transform.position.z);
                rb.velocity = new Vector2(0.0f, 0.0f);
                speed = 0.0f;
                Invoke("Restart", 2);
                CurrentTime = CTime;
            }
            else
            {
                rb.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));

                //Y
                if (transform.position.y < -ScreenHeight + 0.25 && rb.velocity.y < 0 && rb.velocity.x < 0) {
                    angle -= Mathf.PI / 2 + Random.Range(-0.05f, 0.05f);
                    Instantiate(BounceEffect, transform.position, Quaternion.identity);
                    CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                    BounceSound.Play();

                }
                if (transform.position.y < -ScreenHeight + 0.25 && rb.velocity.y < 0 && rb.velocity.x > 0) {
                    angle = 2 * Mathf.PI - angle + Random.Range(-0.05f, 0.05f);
                    Instantiate(BounceEffect, transform.position, Quaternion.identity);
                    CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                    BounceSound.Play();

                }
                if (transform.position.y > ScreenHeight - 0.25 && rb.velocity.y > 0 && rb.velocity.x < 0) {
                    angle += Mathf.PI / 2 + Random.Range(-0.05f, 0.05f);
                    Instantiate(BounceEffect, transform.position, Quaternion.identity);
                    CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                    BounceSound.Play();

                }
                if (transform.position.y > ScreenHeight - 0.25 && rb.velocity.y > 0 && rb.velocity.x > 0) { 
                    angle = 2 * Mathf.PI - angle + Random.Range(-0.05f, 0.05f);
                    Instantiate(BounceEffect, transform.position, Quaternion.identity);
                    CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                    BounceSound.Play();

                }

            }
            
        }
        else
        {
            CDText.gameObject.SetActive(true);

            CDText.text = CurrentTime.ToString("0");
            CurrentTime += -1 * Time.deltaTime;
        }
        
        if(score1 >= gameOver || score2 >= gameOver)
        {
            if (score1 >= gameOver)
                Winner.text = "Player 1 won!";
            else
                Winner.text = "Player 2 won!";
            Game.SetActive(false);
            WinnerMenu.SetActive(true);
            score1 = 0;
            score2 = 0;
            player1.position = new Vector3(player1.position.x, 0.0f, transform.position.z);
            player2.position = new Vector3(player2.position.x, 0.0f, transform.position.z);
        }

    }
    
    public void Restart()
    {

        transform.position = new Vector3(0.0f, 0.0f, transform.position.z);
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        int n = (int)Random.Range(1, 8);
        while (n % 2 == 0)
            n /= 2;
        angle = n * Mathf.PI / 4;
        speed = inputSpeed;
    }

}
