using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class volume : MonoBehaviour
{
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;
    private bool isAudioOn = true;
    private AudioSource audioSource;
    private Image buttonSprite;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonSprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleAudio()
    {
        isAudioOn = !isAudioOn;

        // Toggle audio source
        audioSource.mute = !isAudioOn;
        buttonSprite.sprite = isAudioOn ? audioOnSprite : audioOffSprite;

    
    }
}
