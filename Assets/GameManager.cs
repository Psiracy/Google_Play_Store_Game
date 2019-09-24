using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    Transform startingpos;

    private void Start()
    {
        SummonPlayer();
    }

    public void SummonPlayer()
    {
        Instantiate(playerPrefab,startingpos.position, Quaternion.identity);
    }
}
