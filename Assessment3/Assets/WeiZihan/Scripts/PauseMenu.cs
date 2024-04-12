using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        // 检查是否按下了 ESC 键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 切换暂停状态
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // 显示暂停面板
        pausePanel.SetActive(true);
        // 暂停游戏时间
        Time.timeScale = 0f;
        // 设置暂停状态
        isPaused = true;
    }

    void ResumeGame()
    {
        // 隐藏暂停面板
        pausePanel.SetActive(false);
        // 恢复游戏时间
        Time.timeScale = 1f;
        // 取消暂停状态
        isPaused = false;
    }
}
