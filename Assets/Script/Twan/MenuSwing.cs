using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwing : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    float sensitivity;

    Vector3 offset;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).length - 1 < animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            transform.eulerAngles = new Vector3(0, 0, Input.acceleration.x * sensitivity);
        }
    }
}
