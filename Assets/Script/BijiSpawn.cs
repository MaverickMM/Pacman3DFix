using System.Diagnostics;
using UnityEngine;

public class BijiSpawn : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject pelletPrefab; // Prefab untuk pellet
    public float pelletSize = 0.5f; // Ukuran dari pellet
    public int width = 5; // Lebar dari kotak pellet yang ingin dibuat
    public int height = 5; // Panjang dari kotak pellet yang ingin dibuat
    private int numPellets; // Jumlah total pellet yang ada di scene

    void Start()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 position = new Vector3(transform.position.x + j * pelletSize,
                                               transform.position.y,
                                               transform.position.z + i * pelletSize);

                Collider[] hits = Physics.OverlapBox(position, new Vector3(pelletSize, pelletSize, pelletSize) / 2f);

                if (hits.Length == 0)
                {
                    GameObject pellet = Instantiate(pelletPrefab, position, Quaternion.identity);
                    pellet.transform.parent = transform;
                    numPellets++; // Increase the count of pellets
                }
                else
                {
                    foreach (Collider hit in hits)
                    {
                        if (hit.gameObject.CompareTag("Halang"))
                        {
                            // Destroy(hit.gameObject);
                        }
                    }
                }
            }
        }
    }

    public bool ArePelletsRemaining()
    {
        // Check if there are any pellets left in the scene
        return numPellets > 0;

    }

    public void DecrementPelletCount()
    {
        // Decrement the count of pellets when one is destroyed
        numPellets--;
    }
    void Update()
    {
       if (!ArePelletsRemaining())
       {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
}