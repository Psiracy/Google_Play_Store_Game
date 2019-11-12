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
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.rigidbody);
            gameManager.KillPlayer(collision.transform.position);
            spriteRenderer.sprite = bloodySpike;
        }
    }
}
