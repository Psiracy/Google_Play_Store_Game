using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevelTrans : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu, levelSelect;

    private void Start()
    {
        levelSelect.SetActive(false);
    }

    public void LevelTrans()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }
}
