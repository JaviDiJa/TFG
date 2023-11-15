using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    public void Volver()
    {
        SceneLoader.Instance.RemoveOptionsMenu();
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
