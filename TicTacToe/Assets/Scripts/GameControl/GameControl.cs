using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    GameObject canvasSettings;   
    [SerializeField]
    TMP_Dropdown resDropDown;
    [SerializeField]
    TMP_Dropdown winModeDropDown;
    int screenWidth;
    int screenHeight;
    string windowMode;
    private void Start()
    {
        screenWidth = Screen.currentResolution.width;
        screenHeight = Screen.currentResolution.height;
        switch (Screen.width)
        {
            case 1920:
                resDropDown.value = 0;
                screenWidth = 1920;
                screenHeight = 1080;
                break;
            case 1600:
                resDropDown.value = 1;
                screenWidth = 1600;
                screenHeight = 900;
                break;
            case 1366:
                resDropDown.value = 2;
                screenWidth = 1366;
                screenHeight = 768;
                break;
            case 1280:
                resDropDown.value = 3;
                screenWidth = 1280;
                screenHeight = 720;
                break;
            case 1024:
                resDropDown.value = 4;
                screenWidth = 1280;
                screenHeight = 720;
                break;
            default:
                break;
        }
        switch (Screen.fullScreen)
        {
            case true:
                windowMode = "fullscreen";
                winModeDropDown.value = 0;
                break;
            case false:
                winModeDropDown.value = 1;
                windowMode = "windowed";
                break;
        }
    }
    public void ApplySettings()
    {
        if (windowMode == "fullscreen")
        {
            Screen.SetResolution(screenWidth, screenHeight, true, 60);
        }
        else if (windowMode == "windowed")
        {
            Screen.SetResolution(screenWidth, screenHeight, false, 60);
        }
    }
    public void ScreenSize(int value)
    {
        switch (value)
        {
            case 0:
                screenWidth = 1920;
                screenHeight = 1080;
                break;
            case 1:
                screenWidth = 1600;
                screenHeight = 900;
                break;
            case 2:
                screenWidth = 1366;
                screenHeight = 768;
                break;
            case 3:
                screenWidth = 1280;
                screenHeight = 720;
                break;
            case 4:
                screenWidth = 1024;
                screenHeight = 576;
                break;
            default:
                screenWidth = 1280;
                screenHeight = 720;
                break;
        }
    }
    public void WindowMode(int value)
    {
        switch (value)
        {
            case 0:
                windowMode = "fullscreen";
                break;
            case 1:
                windowMode = "windowed";
                break;
            default:
                windowMode = "windowed";
                break;
        }
    }
    bool activeSettings = false;
    public void SettingsCanvas()
    {
        if (activeSettings == false)
        {
            canvasSettings.SetActive(true);
            activeSettings = true;            
        }
        else
        {
            activeSettings = false;
            canvasSettings.SetActive(false);
        }
    }
    public void QuitGame()
    {
        PhotonNetwork.Disconnect();
        Application.Quit();
    }
}
