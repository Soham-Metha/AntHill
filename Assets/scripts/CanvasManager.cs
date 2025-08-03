using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject Exit;
    [SerializeField] private GameObject LevelCanvas;
    void Start()
    {
        ShowMainMenu();
    }

    public void ShowLevels()
    {
        SettingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        Exit.SetActive(false);
        LevelCanvas.SetActive(true);
    }

    public void ShowMainMenu()
    {
        SettingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        Exit.SetActive(false);
        LevelCanvas.SetActive(false);
    }

    public void ShowSettings()
    {
        SettingsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        Exit.SetActive(false);
        LevelCanvas.SetActive(false);
    }

    public void ShowExit()
    {
        Exit.SetActive(true);
    }

    public void ConfirmExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
        #endif  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
            // You can also call functions, open a pause menu, etc.
        }
    }
}
