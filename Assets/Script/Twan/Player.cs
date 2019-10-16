using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject idle, falling;
    GyroController gyro;
    Easing easing;
    float timer, duration;
    float change, target;
    Direction direction;
    Rigidbody2D rigidBody;
    bool isFalling = false;
    bool hasLanded = false;
    AudioSource audioSource;
    AudioClip fallSound;
    float timeToAllowSound;
    float timeToAllowSoundReset = 0.5f;

    void Start()
    {
        gyro = FindObjectOfType<GyroController>();
        easing = new Easing();
        timer = 0;
        direction = Direction.down;
        duration = 1;
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        fallSound = Resources.Load<AudioClip>("Sound/PlayerFall2,5");
        audioSource.clip = fallSound;
        timeToAllowSound = timeToAllowSoundReset;
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

        //check for ground
        if (IsGrounded(transform.position, -transform.up, .5f, 1 << 9) == true)
        {
            hasLanded = true;
            if (isFalling == true)
            {
                audioSource.Play();
                isFalling = false;
            }
        }
        else
        {
            isFalling = true;
        }

        //animation
        idle.SetActive(IsGrounded(transform.position, -transform.up, .5f, 1 << 9));
        falling.SetActive(!IsGrounded(transform.position, -transform.up, .5f, 1 << 9));
    }

    public bool IsGrounded(Vector2 playerPos, Vector2 direction, float distance, int groundLayer)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerPos, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
