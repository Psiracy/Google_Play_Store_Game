using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaller : MonoBehaviour
{
    Camera cam;
    float offset = .022f;

    void Start()
    {
        cam = Camera.main;
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float size = (cam.orthographicSize / 10) + offset;
        transform.localScale = new Vector3(size, size, size);
    }
}
