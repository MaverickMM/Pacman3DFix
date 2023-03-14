using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilController : MonoBehaviour {
  private AudioSource pil_sound;
  private Renderer pil_renderer;
  private Collider pil_collider;

  void Start() {
    this.pil_renderer = GetComponent<Renderer>();
    this.pil_collider = GetComponent<Collider>();
    this.pil_sound = GetComponent<AudioSource>();
  }
  void Update() {
    //Do nothing
  }

  private void handlePlayerCollision() {
    this.pil_sound.PlayOneShot(this.pil_sound.clip);

    this.pil_renderer.enabled = false;
    this.pil_collider.enabled = false;


    //FIXME: Should we destroy the gameobject or not ?
    // Destroy(gameObject, this.pil_sound.clip.length);
  }

  private void OnTriggerEnter(Collider collision)
  {
    switch (collision.gameObject.tag) {
      case "Player":
        handlePlayerCollision();
        break;
    }
  }
}
