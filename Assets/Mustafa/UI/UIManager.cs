using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Button Level1startButton;
    [SerializeField] Button Level2startButton;
    [SerializeField] Button Level3startButton;
    [SerializeField] Button Level4startButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;

    [SerializeField] GameObject levelTree;
    private void Start()
    {
        Level1startButton.onClick.AddListener(StartGameLevel1);
        Level2startButton.onClick.AddListener(StartGameLevel2);
        Level3startButton.onClick.AddListener(StartGameLevel3);
        Level4startButton.onClick.AddListener(StartGameLevel4);
        optionsButton.onClick.AddListener(OpenOptions);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGameLevel4()
    {
        SceneManager.LoadScene(8);
    }

    private void StartGameLevel3()
    {
        SceneManager.LoadScene(6);
    }

    private void StartGameLevel1()
    {
        SceneManager.LoadScene(1);
    }

    private void StartGameLevel2()
    {
        SceneManager.LoadScene(4);
    }

    public void StartGame()
    {
        SceneController.instance.LoadFirstLevel();
    }
    public void OpenLevelTree()
    {
        levelTree.SetActive(true);
    }
    public void OpenOptions()
    {
        Debug.Log("Options Opened");
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}