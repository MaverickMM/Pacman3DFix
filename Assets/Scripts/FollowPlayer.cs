using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
    }
}
