using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Endstory : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string ha= "After eliminating all the zombies, you found a base and found that it allowed you to enter because your spaceship was broken. So you decided to go inside and search for a way to escape the moon.";
    public float typingSpeed = 0.05f;
    public float waitAfterTyping = 1.2f;
    public float fadeSpeed = 0.5f;
    public float waitBeforeFadeOut = 1.2f;
    public GameObject panel;
  
    private void Start()
    {
        StartCoroutine(TypeText());
        
    }

    IEnumerator TypeText()
    {
        // 等待一秒钟
        yield return new WaitForSeconds(1f);

        // 逐字打印文字
        foreach (char letter in ha)
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 打印完成后等待两秒
        yield return new WaitForSeconds(waitAfterTyping);

        // 文字逐渐消失
        StartCoroutine(FadeOutText());
        
         StartCoroutine(FadeOutScene());
    }

    IEnumerator FadeOutText()
    {
        // 获取文字颜色
        Color textColor = textMeshPro.color;

        // 逐渐将文字透明度减少至0
        while (textMeshPro.color.a > 0)
        {
            textMeshPro.color = textColor;
            yield return null;
        }
       
    }
     IEnumerator FadeOutScene()
        {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += 2f * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("KunScene");
    }
}
