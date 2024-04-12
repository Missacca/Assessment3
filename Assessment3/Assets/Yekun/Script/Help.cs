using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject help;
    private bool ispressed = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)&& !ispressed)
        {
            help.SetActive(true);
            ispressed = true;
        }
        else if (ispressed && Input.GetKeyDown(KeyCode.H))
        {
            help.SetActive(false);
            ispressed = false;
        }
    }
}
