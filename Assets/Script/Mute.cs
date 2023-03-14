using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Button muteButton;
    public Sprite muteImage;
    public Sprite unmuteImage;

    private bool isMuted = false;

    void Start()
    {
        muteButton.onClick.AddListener(ToggleMute);
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        muteButton.image.sprite = isMuted ? unmuteImage : muteImage;
    }
}