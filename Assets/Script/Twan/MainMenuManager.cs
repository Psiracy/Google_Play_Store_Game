using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    SaveData saveData = new SaveData();
    public int levelReached = 0;
    [SerializeField]
    private int maxLevel;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            EmptySaveFile();

        Debug.Log("Level reached: " + levelReached);
    }

    public void GameStart()
    {
        if (levelReached < maxLevel)
            SceneManager.LoadScene("Level" + levelReached);
        else
            SceneManager.LoadScene("Level" + maxLevel);
    }

    public void LevelSelect()
    {
        mainMenuAnimtor.SetTrigger("Transition");
    }

    public void EmptySaveFile()
    {
        string json = PlayerPrefs.GetString("save");
        saveData = JsonUtility.FromJson<SaveData>(json);
        levelReached = 0;
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
