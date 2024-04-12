using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyFind : MonoBehaviour
{
    private bool nearKey = false;
    public bool isGetKey = false;

    public GameObject interact;
    public TextMeshProUGUI interact2;
    public AudioSource pickAudio;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nearKey)
            {
                interact2.color = Color.green;
                pickAudio.Play();
                isGetKey = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            interact.SetActive(true);
            nearKey = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            nearKey = false;
            interact.SetActive(false);
        }
    }
}
