using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMainMenuTrans : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu, levelSelect;

    public void LevelTrans()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }
}
