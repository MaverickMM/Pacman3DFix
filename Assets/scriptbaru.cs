using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptbaru : MonoBehaviour

{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSpeed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotate the character to face the direction it's moving towards
            transform.LookAt(transform.position + direction);

            // Move the character forward
            controller.Move(direction * speed * Time.deltaTime);
        }
        else if (horizontal != 0f)
        {
            // Rotate the character left or right while staying in place
            transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        }
    }
}