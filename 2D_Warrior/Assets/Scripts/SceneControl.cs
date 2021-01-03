using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("MainGame01");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
