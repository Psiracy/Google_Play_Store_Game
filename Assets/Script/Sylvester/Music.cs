using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource _AudioSource;
    [SerializeField] private AudioClip _MenuMusic;
    [SerializeField] private AudioClip _InGameMusic;
    private Scene _CurrentScene;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _AudioSource = GetComponent<AudioSource>();
        _MenuMusic = Resources.Load<AudioClip>("Sound/MenuMusic");
        _InGameMusic = Resources.Load<AudioClip>("Sound/InGameMusic");
        _AudioSource.clip = _MenuMusic;
        PlayMusic();
    }

    private void Update()
    {
        _CurrentScene = SceneManager.GetActiveScene();
        Debug.Log(_CurrentScene.name);

        if (_CurrentScene.name == "Main Menu" && _AudioSource.clip.name != "MenuMusic")
        {
            _AudioSource.clip = _MenuMusic;
            PlayMusic();
        }
        else if (_CurrentScene.name == "LevelSelect(Test)" && _AudioSource.clip.name != "MenuMusic")
        {
            _AudioSource.clip = _MenuMusic;
            PlayMusic();
        }
        else if (_CurrentScene.name == "Level1" || _CurrentScene.name == "Level2" || _CurrentScene.name == "Level3" || _CurrentScene.name == "Level4")
        {
            if (_AudioSource.clip.name != "InGameMusic")
            {
                _AudioSource.clip = _InGameMusic;
                PlayMusic();
            }
        }
    }

    public void PlayMusic()
    {
        if (_AudioSource.isPlaying) return;
        _AudioSource.Play();
    }

    public void StopMusic()
    {
        _AudioSource.Stop();
    }

}
