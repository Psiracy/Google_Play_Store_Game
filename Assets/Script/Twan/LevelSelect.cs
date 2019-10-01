using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    int level;
    int reachedLevel;
    void Start()
    {
      reachedLevel =  FindObjectOfType<InformationHolder>().levelReached;
        if (level > reachedLevel)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level" + level);
    }
}
