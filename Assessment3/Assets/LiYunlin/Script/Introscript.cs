using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introscript : MonoBehaviour
{
   public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float ani;
    public GameObject panel;
    private bool panelVisible = false;
    public AudioSource app;
    void Start()
    {
         StartCoroutine(ShowPanel(panel));
    }
    public void ad()
    {
        StartCoroutine(HidePanel(panel));
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
