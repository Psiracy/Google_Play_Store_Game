using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    SaveData saveData = new SaveData();
    int levelReached = 1;

    private void Start()
    {
        if (!Directory.Exists("Saves"))
        {
            Directory.CreateDirectory("Saves");
        }

        if (!File.Exists("Saves/Save.grg"))
        {
            File.Create("Saves/Save.grg");
            saveData.levelReached = levelReached;
            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText("Saves/Save.grg", json);
        }
        else
        {
            string json = File.ReadAllText("Saves/Save.grg");
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
        GameObject infoHolder = new GameObject();
        infoHolder.AddComponent<InformationHolder>();
        infoHolder.GetComponent<InformationHolder>().levelReached = levelReached;
        DontDestroyOnLoad(infoHolder);
        SceneManager.LoadScene(1);
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
