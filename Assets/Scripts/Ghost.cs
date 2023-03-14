
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Player player;
    private bool isPacmanImmune;

    public void Start()
    {
        // Mencari objek Player
        player = FindObjectOfType<Player>();
        isPacmanImmune = player.GetPacmanImmuneStatus();
    }

    // Kondisi ketika Ghost dibunuh Pacman dan sebaliknya
    private void OnTriggerEnter(Collider collision)
    {
        // Ghost Dibunuh Pacman
        if (collision.gameObject.tag == "Player" && isPacmanImmune == true)
        {
            transform.position = new Vector3((float)-5, (float)0.7, (float)3.32);
        }
        // Pacman Dibunuh Ghost
        else if (collision.gameObject.tag == "Player" && isPacmanImmune == false)
        {
            Destroy(player.gameObject);
        }
    }
}



