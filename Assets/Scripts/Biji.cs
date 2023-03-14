using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biji : MonoBehaviour
{ 
  private AudioSource biji_sound;
  private Renderer biji_renderer;
  private Collider biji_collider;

  void Start() {
    this.biji_sound = GetComponent<AudioSource>();
    this.biji_renderer = GetComponent<Renderer>();
    this.biji_collider = GetComponent<Collider>();
  }

  private void handlePlayerCollision() {
    this.biji_sound.PlayOneShot(this.biji_sound.clip);
    
    ScoreManager.instance.AddPoint();

    this.biji_renderer.enabled = false;
    this.biji_collider.enabled = false;

    Destroy(gameObject, this.biji_sound.clip.length);
  }

  private void OnTriggerEnter(Collider collision)
  {
    switch (collision.gameObject.tag) {
      case "Player":
        this.handlePlayerCollision();
        break;
    }
  }
}