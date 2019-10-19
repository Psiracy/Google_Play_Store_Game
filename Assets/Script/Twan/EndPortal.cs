using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EndPortal : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    [SerializeField]
    int level;

    SaveData saveData = new SaveData();
    LevelData levelData = new LevelData();

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.HasKey("save"))
        {
            string json = PlayerPrefs.GetString("save");
            saveData = JsonUtility.FromJson<SaveData>(json);
            if (saveData.levelReached < level)
            {
                saveData.levelReached = level;
                json = JsonUtility.ToJson(saveData);
                PlayerPrefs.SetString("save", json);
            }
        }
        else
        {
            saveData.levelReached = level;
            string json = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString("save", json);
        }

        level--;
        levelData.level = level;
        levelData.time = gameManager.levelTimer;

        if (PlayerPrefs.HasKey("level" + level))
        {
            string levelJson = PlayerPrefs.GetString("level" + level);
            LevelData oldLevelData = JsonUtility.FromJson<LevelData>(levelJson);
            if (levelData.time > oldLevelData.time)
            {
                levelData.time = oldLevelData.time;
            }
        }

        PlayerPrefs.SetString("level" + level, JsonUtility.ToJson(levelData));

        SceneManager.LoadScene(sceneName);
    }
}
