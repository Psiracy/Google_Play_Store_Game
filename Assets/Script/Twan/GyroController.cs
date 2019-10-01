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
    Direction direction;
    Vector2 gravity;
    public bool testOnPC;
    void Start()
    {
        gravity = Physics2D.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (testOnPC == false)
        {
            if (Input.acceleration.y < -.1f)
            {
                direction = Direction.down;
            }
            if (Input.acceleration.y > .1f)
            {
                direction = Direction.up;
            }
            if (Input.acceleration.x < -.5f)
            {
                direction = Direction.left;
            }
            if (Input.acceleration.x > .5f)
            {
                direction = Direction.right;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                direction = Direction.down;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = Direction.up;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Direction.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Direction.right;
            }
        }

        switch (direction)
        {
            case Direction.down:
                gravity = new Vector2(0, -9.81f);
                break;
            case Direction.left:
                gravity = new Vector2(-9.81f / 2, 0);
                break;
            case Direction.right:
                gravity = new Vector2(9.81f / 2, 0);
                break;
            case Direction.up:
                gravity = new Vector2(0, 9.81f);
                break;
            default:
                break;
        }

        Physics2D.gravity = gravity;
    }

    public Direction GetDirection
    {
        get
        {
            return direction;
        }
    }
}
