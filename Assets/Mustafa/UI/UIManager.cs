using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Button startButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;

    [SerializeField] GameObject levelTree;
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        exitButton.onClick.AddListener(ExitGame);
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