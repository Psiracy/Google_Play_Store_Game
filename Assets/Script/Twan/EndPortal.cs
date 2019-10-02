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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string json = PlayerPrefs.GetString("save");
        saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData.levelReached < level)
        {
            saveData.levelReached = level;
            json = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString("save", json);
        }
        SceneManager.LoadScene(sceneName);
    }
}
