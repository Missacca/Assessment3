using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookGuide : MonoBehaviour
{
    private bool nearNote = false; 
    private bool readingNote = false; 
    private bool movementLocked = false; 


    public GameObject noteUI; 
    public GameObject interact;
    public GameObject interact2;
    public GameObject interact3;
    public TextMeshProUGUI interact4;
    public AudioSource flipAudio;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nearNote && !readingNote)
            {
                
                ShowNotePrompt();
                interact4.color = Color.green;
                LockMovement();
            }
            else if (readingNote)
            {
              
                HideNotePrompt();
                interact.SetActive(false);
                UnlockMovement();
            }
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note")) 
        {
            interact.SetActive(true);
            nearNote = true;
        }
    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            interact2.SetActive(true);
            interact3.SetActive(true);
            interact.SetActive(false);
            nearNote = false;
            HideNotePrompt();
        }
    }

    
    void ShowNotePrompt()
    {
        flipAudio.Play();
        noteUI.SetActive(true);
        readingNote = true;
    }

    
    void HideNotePrompt()
    {
        noteUI.SetActive(false);
        readingNote = false;
    }

    
    void LockMovement()
    {
        GetComponent<PlayerMovement > ().enabled = false;
        movementLocked = true;
    }

 
    void UnlockMovement()
    {
        GetComponent <PlayerMovement > ().enabled = true;
        movementLocked = false;
    }
}
