using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        // ����Ƿ����� ESC ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �л���ͣ״̬
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
        // ��ʾ��ͣ���
        pausePanel.SetActive(true);
        // ��ͣ��Ϸʱ��
        Time.timeScale = 0f;
        // ������ͣ״̬
        isPaused = true;
    }

    void ResumeGame()
    {
        // ������ͣ���
        pausePanel.SetActive(false);
        // �ָ���Ϸʱ��
        Time.timeScale = 1f;
        // ȡ����ͣ״̬
        isPaused = false;
    }
}
