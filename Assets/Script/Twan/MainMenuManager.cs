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
    private int maxLevel;
    [SerializeField]
    Animator mainMenuAnimator, levelSelectAnimator;
    [SerializeField]
    GameObject deleteSave;

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

        deleteSave.SetActive(false);
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
        mainMenuAnimator.SetTrigger("Transition");
    }

    public void MainMenu()
    {
        levelSelectAnimator.SetTrigger("Transition");
    }

    public void OpenDeleteSaveMenu()
    {
        deleteSave.SetActive(true);
    }

    public void CloseDeleteSaveMenu()
    {
        deleteSave.SetActive(false);
    }

    public void EmptySaveFile()
    {
        PlayerPrefs.DeleteAll();
        levelReached = 1;
        deleteSave.SetActive(false);
        SceneManager.LoadScene(0);
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

struct LevelData
{
    public int level;
    public float time;
}
