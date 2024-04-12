using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Escape : MonoBehaviour
{
    private KeyFind isFindkey;
    private bool nearShip = false;
    private bool movementLocked = false;
    private bool isEdown = false;


    public GameObject interact;
    public TextMeshProUGUI interact2;
    public GameObject EndWords;
    public GameObject warn;
    public AudioSource Flyout;

    
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFindkey = GetComponent<KeyFind>();
            if (nearShip && isFindkey.isGetKey)
            {
                
                interact.SetActive(false);
                EndWords.SetActive(true);
                interact2.color = Color.green;
                LockMovement();
                isEdown = true;
                Flyout.Play();
            }
            else if (!isFindkey.isGetKey && nearShip)
            {
                warn.SetActive(true);
                interact.SetActive(false);
                UnlockMovement();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && isEdown)
        {
            Debug.Log("R key pressed!");
            SceneManager.LoadScene("Menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            interact.SetActive(true);
            nearShip = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("End"))
        {
            warn.SetActive(false);
            nearShip = false;
        }
    }

    void LockMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
        movementLocked = true;
    }


    void UnlockMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
        movementLocked = false;
    }
}
