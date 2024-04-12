using System;
using System.Collections;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sceneintro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string ha;
    public float typingSpeed = 0.05f;
    public float waitAfterTyping = 1.2f;
    public float fadeSpeed = 0.5f;
    public float waitBeforeFadeOut = 1.2f;
    public GameObject panel;
    public GameObject a;
    public AudioSource b;
    private void Start()
    {
        StartCoroutine(TypeText());
        a.SetActive(false);
    }

    IEnumerator TypeText()
    {
        // 等待一秒钟
        yield return new WaitForSeconds(1f);
         b.Play();

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
         a.SetActive(true);
         StartCoroutine(FadeOutScene());
    }

    IEnumerator FadeOutText()
    {
        // 获取文字颜色
        Color textColor = textMeshPro.color;

        // 逐渐将文字透明度减少至0
        while (textMeshPro.color.a > 0)
        {
            textColor.a -= fadeSpeed * Time.deltaTime;
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
        SceneManager.LoadScene("Game");
    }
}
