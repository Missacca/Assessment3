using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAudioPlayer : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource hoverSound;
    public AudioSource clickSound;

    void Start()
    {
        // Ensure we have AudioSource components
        if (hoverSound == null || clickSound == null)
        {
            Debug.LogError("One or more AudioSources are not assigned to ButtonSound script!");
            enabled = false;
            return;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play hover sound when pointer enters the button
        if (GetComponent<Button>().interactable)
            hoverSound.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play click sound when button is clicked
        if (GetComponent<Button>().interactable)
            clickSound.Play();
    }
}
