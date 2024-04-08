using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
      public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float ani;
    public GameObject panel;
    private bool panelVisible = false;

    void Update()
    {
        // 显示面板的条件判断改为按下空格键并且面板当前不可见
        if (Input.GetKeyDown(KeyCode.Space) && !panelVisible)
        {
            StartCoroutine(ShowPanel(panel));
            panelVisible = true;
            
        }
        // 隐藏面板的条件判断改为按下 ESC 键并且面板当前可见
        else if (Input.GetKeyDown(KeyCode.Escape) && panelVisible)
        {
            StartCoroutine(HidePanel(panel));
            panelVisible = false;
             Time.timeScale = 1;
        }
    }

    IEnumerator ShowPanel(GameObject z)
    {
        float a = 0;
        while (a <= 1)
        {
            z.transform.localScale = Vector3.one * showCurve.Evaluate(a);
            a += Time.deltaTime * ani;
            yield return null;
        }
        Time.timeScale = 0;
    }

    IEnumerator HidePanel(GameObject z)
    {
        float a = 0;
        while (a <= 1)
        {
            z.transform.localScale = Vector3.one * hideCurve.Evaluate(a);
            a += Time.deltaTime * ani;
            yield return null;
        }
    }
}
