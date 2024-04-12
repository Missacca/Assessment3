using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sceneintro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string ha="Finally, you managed to evade the attack and reach the solar system. But your ship is running low on fuel, and you are forced to land on the moon, where the Earth Guard has established a space base. After you put on your portable oxygen and land on the lunar surface, your lunar guard team has been turned into zombies by aliens and is roaming the lunar surface. And you find that the number of zombies is far beyond your imagination, and their attack power is also very powerful. You must use your weapons to fight zombies to the death, protect the moon base, and save the Earth!!!";
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
        SceneManager.LoadScene("Game2");
    }
}
