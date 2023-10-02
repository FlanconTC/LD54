using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoxSpawning : MonoBehaviour
{
    public GameObject[] boxPrefabs; // Tableau des différents types de boîtes
    public int numberOfBoxes = 3; // Nombre de boîtes à générer
    public float spawnRadius = 5f; // Rayon dans lequel les boîtes seront générées
    private float timeSinceLastPop = 0f;
    private float popInterval = 33f;
    void Start()
    {
        for (int i = 0; i < numberOfBoxes; i++)
        {
            GameObject randomBoxPrefab = boxPrefabs[Random.Range(0, boxPrefabs.Length)];
            Vector3 randomSpawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomSpawnPosition.z = 0f;
            Instantiate(randomBoxPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }





    private void Update()
    {
        timeSinceLastPop += Time.deltaTime;

        if (timeSinceLastPop >= popInterval)
        {
            timeSinceLastPop = 0f;
           StartCoroutine(GenerateBox());
        }
    }


    IEnumerator GenerateBox() 
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < numberOfBoxes; i++)
        {
            GameObject randomBoxPrefab = boxPrefabs[Random.Range(0, boxPrefabs.Length)];
            Vector3 randomSpawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomSpawnPosition.z = 0f;
            Instantiate(randomBoxPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
