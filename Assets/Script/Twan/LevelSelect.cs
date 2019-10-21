using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    int level;
    [SerializeField]
    Sprite complededImage, complededImagePressed;
    int reachedLevel;
    void Start()
    {
      reachedLevel =  FindObjectOfType<MainMenuManager>().levelReached;
        if (level > reachedLevel)
        {
            GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.HasKey("level" + level))
        {
            //set the sprites
            GetComponent<Image>().sprite = complededImage;
            SpriteState spriteState = new SpriteState();
            spriteState.pressedSprite = complededImagePressed;
            GetComponent<Button>().spriteState = spriteState;
            //set the time
            string levelJson = PlayerPrefs.GetString("level" + level);
            LevelData levelData = JsonUtility.FromJson<LevelData>(levelJson);
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(levelData.time);
            string time = timeSpan.ToString("mm':'ss':'ff");
            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = time;
        }
        else
        {
            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = string.Empty;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level" + level);
    }
}
