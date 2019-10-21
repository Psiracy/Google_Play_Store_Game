using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    Sprite bloodySpike;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.rigidbody);
        Destroy(collision.transform.GetComponent<Player>());
        gameManager.KillPlayer(collision.transform.position);
        spriteRenderer.sprite = bloodySpike;
    }
}
