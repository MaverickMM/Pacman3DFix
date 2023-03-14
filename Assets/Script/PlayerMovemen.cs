// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovemen : MonoBehaviour
// {
//     public float speed;
//     public float rotationSpeed;
//     public Animator animasi;
//     private Camera mainCamera;
//     public Transform spawn;


//     private float timer = 0f;
//     private bool canMove = true;
//     private GameObject[] CollideGhost = new GameObject[0];

//     public float powerPelletDuration = 5f;
//     public bool isPowerPelletActive = false;
//     public float powerPelletTimer = 0f;
    

//     // Start is called before the first frame update
//     void Start()
//     {
//         mainCamera = Camera.main;
//         animasi = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");

//         // Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
//         Vector3 movementDirection = mainCamera.transform.TransformDirection(new Vector3(horizontalInput, 0f, verticalInput)).normalized;
        
//         if (movementDirection.magnitude > 0.1f)
//         {
//             movementDirection.Normalize();
//             transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

//             animasi.SetBool("Jalan", true);

//             // Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
//             // transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
//         }
//         else
//         {
//             animasi.SetBool("Jalan", false);
//         }

        

//          if (isPowerPelletActive)
//         {
//             powerPelletTimer += Time.deltaTime;

//             if (powerPelletTimer >= powerPelletDuration)
//             {
//                 isPowerPelletActive = false;
//                 powerPelletTimer = 0f;
//             }
//         }

//         if (isPowerPelletActive)
//         {
//             speed = 8f;
//         }
//         else
//         {
//             speed = 5f;
//         }

//         if (!canMove)
// {
//         timer += Time.deltaTime;
        
//         if (timer >= 3f)
//         {
//             if (CollideGhost.Length > 0) // Check if there are any collided ghosts
//             {
//                 for (int i = 0; i < CollideGhost.Length; i++) // Loop through each collided ghost
//                 {
//                     GameObject ghost = CollideGhost[i];
//                     AIController otherController = ghost.GetComponent<AIController>();
//                     otherController.speedWalk = 3f;
//                     otherController.speedRun = 5f;
//                 }
//                 canMove = true;
//                 timer = 0f;
//                 CollideGhost = new GameObject[0]; // Clear the collidedGhosts array
//             }
//         }
//     }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("PowerPellet"))
//         {
//             // activate power pellet
//             isPowerPelletActive = true;
//             // powerPelletTimer = 0f;

//             // increase score
//             // GameManager.instance.IncreaseScore();

//             // destroy power pellet
//             Destroy(other.gameObject);
//         }

//     if (other.CompareTag("Ghost") && isPowerPelletActive)
//     {
//         ScoreManager.instance.AddPointGhost();
//         AIController otherController = other.gameObject.GetComponent<AIController>();
//         other.gameObject.transform.position = spawn.transform.position;
//         otherController.speedWalk = 0f;
//         otherController.speedRun = 0f;
//         canMove = false;
        
//         // Add collided ghost to the array
//         Array.Resize(ref CollideGhost, CollideGhost.Length + 1);
//         CollideGhost[CollideGhost.Length - 1] = other.gameObject;
//     }
//         if (other.CompareTag("Ghost") && !isPowerPelletActive)
//         {

//             // Destroy(gameObject);
//         }
//     }
// }