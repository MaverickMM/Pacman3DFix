using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testScript : MonoBehaviour
{
    public GameObject bijiPrefab; // Objek biji yang akan diduplikat
    public int bijiCount = 100; // Jumlah biji yang akan dibuat
    public float spawnRadius = 10f; // Radius area tempat biji akan diduplikat
    public float spacing = 0.5f; // Jarak antara biji yang dihasilkan
    public Vector2 spawnOrigin = Vector2.zero; // Posisi asal dari spawner

    void Start()
    {
        // Loop untuk membuat banyak biji
        for (int i = 0; i < bijiCount; i++)
        {
            // Hitung posisi biji berdasarkan indeks loop
            float x = Mathf.Floor(i / spawnRadius);
            float z = i % spawnRadius;
            
            // Hitung posisi akhir dengan jarak yang ditentukan
            Vector3 spawnPos = new Vector3(spawnOrigin.x + x * spacing, 0f, spawnOrigin.y + z * spacing);

            // Cek apakah ada collider pada posisi biji
            Collider[] hitColliders = Physics.OverlapSphere(spawnPos, 0.2f);
            if (hitColliders.Length > 0)
            {
                // Jika ada, ubah posisi biji
                spawnPos += new Vector3(spacing, 0f, spacing);
            }
            
            // Instantiate klon objek biji
            GameObject biji = Instantiate(bijiPrefab, spawnPos, Quaternion.identity);

            // Set parent dari klon objek biji ke GameObject ini
            biji.transform.parent = transform;
        }
    }
}