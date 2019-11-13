using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private Animator _PauseMenuAnimator;

    private void Start()
    {
        _PauseMenuAnimator.SetBool("IsPaused", false);
    }

    public void OpenPauseMenu()
    {
        _PauseMenuAnimator.SetBool("IsPaused", true);
    }

    public void ClosePauseMenu()
    {
        _PauseMenuAnimator.SetBool("IsPaused", false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuTest");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
