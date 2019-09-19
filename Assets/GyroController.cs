using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    down,
    left,
    right,
    up
}

public class GyroController : MonoBehaviour
{
    [SerializeField]
    Text text;
    Direction direction;
    Vector2 gravity;
    // Start is called before the first frame update
    void Start()
    {
        gravity = Physics2D.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Input.acceleration.y.ToString();

        if (Input.acceleration.y < -.1f)
        {
            direction = Direction.down;
        }
        if (Input.acceleration.y > .1f)
        {
            direction = Direction.up;
        }
        if (Input.acceleration.x < -.65f)
        {
            direction = Direction.left;
        }
        if (Input.acceleration.x > .65f)
        {
            direction = Direction.right;
        }

        switch (direction)
        {
            case Direction.down:
                text.text = "down";
                gravity = new Vector2(0, -9.81f);
                break;
            case Direction.left:
                text.text = "left";
                gravity = new Vector2(-9.81f, 0);
                break;
            case Direction.right:
                text.text = "right";
                gravity = new Vector2(9.81f, 0);
                break;
            case Direction.up:
                text.text = "up";
                gravity = new Vector2(0, 9.81f);
                break;
            default:
                break;
        }

        Physics2D.gravity = gravity;
    }
}
