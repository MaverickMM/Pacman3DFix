using System.Diagnostics;
using System.Net.NetworkInformation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;

    // kecepatan pacman/player
    [SerializeField] private float speed = 5.0f;

    [Tooltip("Is Player Immune to Ghosts?")]
    [SerializeField] private bool isImmune = false;
    public void Update()
    {
        HandleMovement();
    }
    public bool GetPacmanImmuneStatus()
    {
        return isImmune;
    }
    private void HandleMovement()
    {
        // move player
        Vector2 inputVector = gameInput.GetMovementVectorNormailzed();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        // membuat collider untuk player agar tidak bisa melewati object
        float playerRadius = 0.4f;
        float playerHeight = 2.0f;
        float moveDistance = speed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        // cek apakah ada object yang menghalangi Player
        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);
            UnityEngine.Debug.Log(canMove);

            if (canMove)
            {
                // Can move only on the X
                moveDirection = moveDirectionX;
            }
            else if (!canMove)
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        // Memutar muka pacman sesuai arah gerakan
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
        private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            UnityEngine.Debug.Log("Tabrak Ghost");
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Kapsul")
        {
            UnityEngine.Debug.Log("Tabrak Ghost");
            
        }
    }
}
