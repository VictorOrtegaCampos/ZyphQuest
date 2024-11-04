using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] string mainMenuScene;

    // [SerializeField] FloorBehaviour floor;

    public delegate void OnPauseDelegate(bool isPaused);
    event OnPauseDelegate OnPauseEvent;

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);

        // Otra forma de hacerlo, sin eventos
        //floor.transform.eulerAngles = new Vector3(0, 0, 0);
        //floor.ResetPosition();

        if (OnPauseEvent != null)
        {
            OnPauseEvent(true);
        }
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        this.gameObject.SetActive(true);
        if (OnPauseEvent != null)
        {
            OnPauseEvent(false);
        }
    }

    public void RegisterOnPause(OnPauseDelegate function)
    {
        OnPauseEvent += function;
    }

    public void UnregisterOnPause(OnPauseDelegate function)
    {
        OnPauseEvent -= function;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}