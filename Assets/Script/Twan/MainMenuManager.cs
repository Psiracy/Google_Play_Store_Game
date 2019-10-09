using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    SaveData saveData = new SaveData();
    public int levelReached = 1;
    [SerializeField]
    Animator mainMenuAnimtor;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("save"))
        {
            saveData.levelReached = levelReached;
            string json = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString("save", json);
        }
        else
        {
            string json = PlayerPrefs.GetString("save");
            saveData = JsonUtility.FromJson<SaveData>(json);
            levelReached = saveData.levelReached;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Level" + levelReached);
    }

    public void LevelSelect()
    {
        mainMenuAnimtor.SetTrigger("Transition");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

struct SaveData
{
    public int levelReached;
}
