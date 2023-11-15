using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenuManager : MonoBehaviour
{
    public void Volver()
    {
        SceneLoader.Instance.RemoveCreditsScene();
        SceneLoader.Instance.LoadMainMenu();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Volver();
        }
    }
}
