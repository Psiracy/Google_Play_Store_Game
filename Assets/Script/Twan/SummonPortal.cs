using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPortal : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    GameObject currentPlayerObject;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlayerSpawn()
    {
        currentPlayerObject = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        gameManager.currentPlayer = currentPlayerObject;
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }

    public void DestroyPlayer()
    {
        Destroy(gameManager.currentPlayer);
        gameManager.SummonPlayer();
    }
}
