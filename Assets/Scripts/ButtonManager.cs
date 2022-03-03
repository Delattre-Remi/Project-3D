using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
