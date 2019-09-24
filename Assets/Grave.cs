using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    int layermask = 1 >> 8;
    void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 3f, ~layermask, -401, -380);
        if (hit.collider != null)
        {
            transform.position = hit.point;

        }
    }
}
