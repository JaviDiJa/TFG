using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject exitMenu;

    [SerializeField] float tiempoEspera;
    [SerializeField] float tiempoUltimaApertura;

    [SerializeField] bool puedeDesactivar;

    public void LoadGame()
    {
        SceneLoader.Instance.RemoveMainMenu();
        SceneLoader.Instance.LoadGameLogicScene();
        SceneLoader.Instance.LoadGameScene1();
    }

    public void LoadOptionsMenu()
    {
        SceneLoader.Instance.RemoveMainMenu();
        SceneLoader.Instance.LoadOptionsMenu();
    }

    public void LoadCreditsMenu()
    {
        SceneLoader.Instance.RemoveMainMenu();
        SceneLoader.Instance.LoadCreditsScene();
    }

    public void CloseExitMenu()
    {
        exitMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        CloseExitMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            exitMenu.SetActive(true);
        }
    }
}
