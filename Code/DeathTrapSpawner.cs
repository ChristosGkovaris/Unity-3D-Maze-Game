using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapSpawner : MonoBehaviour
{
    public GameObject deathTrapPrefab; // Prefab της παγίδας
    public float spawnInterval = 10f; // Χρονικό διάστημα μεταξύ εμφανίσεων
    public float minLifetime = 3f; // Ελάχιστη διάρκεια
    public float maxLifetime = 8f; // Μέγιστη διάρκεια

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        int attempts = 0;

        do
        {
            float x = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;
            float z = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;
            randomPosition = new Vector3(x, 3.5f, z);

            attempts++;
            if (attempts > 100)
            {
                Debug.LogWarning("Δεν βρέθηκε έγκυρη θέση για την παγίδα.");
                break;
            }
        }
        while (Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Walls")) || // Έλεγχος για τοίχους
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Collectible")) || // Έλεγχος για θησαυρούς
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Player")) // Έλεγχος για τον Bob
        );

        return randomPosition;
    }

    private IEnumerator SpawnDeathTraps()
    {
        while (true)
        {
            Vector3 spawnPosition = GetRandomPosition();
            GameObject deathTrap = Instantiate(deathTrapPrefab, spawnPosition, Quaternion.identity);

            float lifetime = Random.Range(minLifetime, maxLifetime);
            Destroy(deathTrap, lifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnDeathTraps());
    }
}