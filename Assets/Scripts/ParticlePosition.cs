using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition : MonoBehaviour
{
    public bool isBlue = true;
    public float offset = 0;

    private float ScreenWidth;

    void Update()
    {
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        if (isBlue)
            ScreenWidth = -ScreenWidth;

        transform.position = new Vector3(ScreenWidth, offset, transform.position.z);
    }
}
