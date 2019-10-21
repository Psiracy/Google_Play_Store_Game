using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab, portal, deathPortal;
    [SerializeField]
    Transform startingpos;

    public GameObject currentPlayer;
    public float levelTimer;

    private void Start()
    {
        SummonPlayer();
    }

    public void SummonPlayer()
    {
        Instantiate(portal, startingpos.position, Quaternion.identity);
    }

    public void KillPlayer(Vector3 deathPos)
    {
        Instantiate(deathPortal, deathPos, Quaternion.identity);
    }

    void Update()
    {
        levelTimer += Time.deltaTime;
    }
}
