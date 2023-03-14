using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSong : MonoBehaviour
{
    public Button muteButton1;
    public Sprite muteImage1;
    public Sprite unmuteImage1;

    private bool isMuted = false;

    void Start1()
    {
        muteButton1.onClick.AddListener(ToggleMute1);
    }

    void ToggleMute1()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        muteButton1.image.sprite = isMuted ? unmuteImage1 : muteImage1;
    }
}