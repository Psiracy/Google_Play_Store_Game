using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    GameObject grave;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject portal;
    [SerializeField]
    GameObject collectable;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(grave, new Vector3(collision.transform.position.x, collision.transform.position.y, 0), transform.parent.rotation);
        Destroy(collision.gameObject);
        gameManager.SummonPlayer();

        if (GameObject.Find("Collectable") != null)
        {
            portal.SetActive(false);
            collectable.SetActive(true);
        }
    }
}
