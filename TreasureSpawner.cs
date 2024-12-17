using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject[] treasurePrefabs; // Λίστα από Prefabs
    public float spawnInterval = 5f; // Χρονικό διάστημα μεταξύ εμφανίσεων
    public float lifetime = 10f; // Χρόνος που μένει ο θησαυρός πριν εξαφανιστεί

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        int attempts = 0;

        do
        {
            // Υπολογισμός τυχαίας θέσης με κεντραρισμένο offset
            float x = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f; // Offset 5 για να πετύχεις (5, 15, 25, ...)
            float z = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;

            // Τοποθέτηση στο κέντρο του grid
            randomPosition = new Vector3(x, 3.5f, z);

            attempts++;

            // Αν ξεπεραστεί ο μέγιστος αριθμός προσπαθειών, σταματάμε
            if (attempts > 100)
            {
                Debug.LogWarning("Δεν βρέθηκε έγκυρη θέση για τον θησαυρό.");
                break;
            }
        }
        // Έλεγχος αν η θέση είναι ελεύθερη και δεν ακουμπάει τοίχους
        while (Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Walls")) || // Έλεγχος για τοίχους
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("DeathTraps")) || // Έλεγχος για παγίδες
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Player")) // Έλεγχος για τον Bob
        );

        return randomPosition;
    }



    private IEnumerator SpawnTreasure()
    {
        while (true)
        {
            // Επιλέγει τυχαία ένα Prefab από τη λίστα
            GameObject randomPrefab = treasurePrefabs[Random.Range(0, treasurePrefabs.Length)];
            
            // Δημιουργία θησαυρού με σωστή περιστροφή
            Vector3 spawnPosition = GetRandomPosition();
            GameObject treasure = Instantiate(randomPrefab, spawnPosition, Quaternion.Euler(0, 90, 90)); // Περιστροφή 90 μοίρες στον Y άξονα

            // Καταστροφή μετά από lifetime δευτερόλεπτα
            Destroy(treasure, lifetime);

            // Αναμονή πριν τον επόμενο θησαυρό
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Start()
    {
        // Έναρξη της διαδικασίας δημιουργίας θησαυρών
        StartCoroutine(SpawnTreasure());
    }
}
