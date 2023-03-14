using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Controller : MonoBehaviour
{
    private AudioSource star_sound;
    private Animator star_animator;
    private Collider star_collider;

    public void Start() {
      this.star_sound = GetComponent<AudioSource>();
      this.star_animator = GetComponent<Animator>();
      this.star_collider = GetComponent<Collider>();
    }

    private void handlePlayerCollision() {
      this.star_sound.PlayOneShot(this.star_sound.clip);
      ScoreManager.instance.AddPoint();

      this.star_animator.enabled = false;
      this.star_collider.enabled = false;

      //FIXME: Add some renderer to disable or destroy the game object instantly without disrupting audio to play.
      Destroy(gameObject, this.star_sound.clip.length);
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
