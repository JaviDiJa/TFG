using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string staticScene = "StaticScene";
    [SerializeField] private string mainMenuScene = "MainMenuScene";
    [SerializeField] private string gameScene1 = "GameScene1";
    [SerializeField] private string gameScene2 = "GameScene2";
    [SerializeField] private string gameScene3 = "GameScene3";
    [SerializeField] private string gameLogicScene = "GameLogicScene";
    [SerializeField] private string optionsMenuScene = "OptionsMenuScene";
    //[SerializeField] private string optionsGameMenuScene = "OptionsMenuGameScene";
    //[SerializeField] private string deathMenuScene = "DeathScene";
    [SerializeField] private string creditsMenuScene = "Creditos";

    [SerializeField] private Canvas pauseMenu;

    private static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(mainMenuScene, LoadSceneMode.Additive);
    }

    public void RemoveMainMenu()
    {
        SceneManager.UnloadSceneAsync(mainMenuScene);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadSceneAsync(optionsMenuScene, LoadSceneMode.Additive);
    }

    public void RemoveOptionsMenu()
    {
        SceneManager.UnloadSceneAsync(optionsMenuScene);
    }

    public void LoadGameScene1()
    {
        SceneManager.LoadSceneAsync(gameScene1, LoadSceneMode.Additive);

    }
    public void RemoveGameScene1()
    {
        SceneManager.UnloadSceneAsync(gameScene1);
    }

    public void LoadGameScene2()
    {
        SceneManager.LoadSceneAsync(gameScene2, LoadSceneMode.Additive);
    }

    public void RemoveGameScene2()
    {
        SceneManager.UnloadSceneAsync(gameScene2);
    }

    public void LoadGameScene3()
    {
        SceneManager.LoadSceneAsync(gameScene3, LoadSceneMode.Additive);
    }

    public void RemoveGameScene3()
    {
        SceneManager.UnloadSceneAsync(gameScene3);
    }

    public void LoadGameLogicScene()
    {
        SceneManager.LoadSceneAsync(gameLogicScene, LoadSceneMode.Additive);
    }

    public void RemoveGameLogicScene()
    {
        SceneManager.UnloadSceneAsync(gameLogicScene);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadSceneAsync(creditsMenuScene, LoadSceneMode.Additive);
    }

    public void RemoveCreditsScene()
    {
        SceneManager.UnloadSceneAsync(creditsMenuScene);
    }
}
