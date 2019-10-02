using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GyroController gyro;
    Easing easing;
    float timer, duration;
    float change, target;
    bool isCoroutineRunning = false;
    Direction direction;

    void Start()
    {
        gyro = FindObjectOfType<GyroController>();
        easing = new Easing();
        timer = 0;
        direction = Direction.down;
        duration = 1;
    }

    void Update()
    {
        //timer
        timer += Time.deltaTime * .5f;
        timer = Mathf.Clamp(timer, 0, duration);

        //set target
        switch (gyro.GetDirection)
        {
            case Direction.down:
                target = 0;
                break;
            case Direction.left:
                target = 270;
                break;
            case Direction.right:
                target = 90;
                break;
            case Direction.up:
                target = 180;
                break;
            default:
                break;
        }

        //set de change
        change = Mathf.Abs(transform.eulerAngles.z - target);

        if (transform.eulerAngles.z - target >= 0)
        {
            change = -change;
        }

        //reset timer if direction change has been made before finishing 
        if (gyro.GetDirection != direction)
        {
            timer = 0;
        }

        direction = gyro.GetDirection;

        //easing
        float z = easing.Ease(transform.eulerAngles.z, change, duration, EaseCurve.Bounce, EaseType.Out, timer);
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
