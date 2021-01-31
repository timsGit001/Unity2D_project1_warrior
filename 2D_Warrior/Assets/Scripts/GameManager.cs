using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// 暫停遊戲
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    
    /// <summary>
    /// 回復遊戲
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
    }

}
