using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
