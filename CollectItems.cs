using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;
    public GameObject collectEffect;
    public int cherryPoints = 1;
    public int lemonPoints = 2;
    public int orangePoints = 3;

    private ScoreManager scoreManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Έλεγχος για θησαυρούς
        if (other.CompareTag("Collectible"))
        {
            // Προσθήκη πόντων ανάλογα με τον θησαυρό
            if (other.name.Contains("cherry"))
            {
                scoreManager.AddScore(cherryPoints);
            }
            else if (other.name.Contains("lemon"))
            {
                scoreManager.AddScore(lemonPoints);
            }
            else if (other.name.Contains("orange"))
            {
                scoreManager.AddScore(orangePoints);
            }

            // Εφέ και ήχος
            if (collectEffect != null)
            {
                GameObject effect = Instantiate(collectEffect, other.transform.position, Quaternion.identity);
                Destroy(effect, 2f);
            }

            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Καταστροφή θησαυρού
            StartCoroutine(ShrinkAndDestroy(other.gameObject));
        }

        // Έλεγχος για παγίδες
        if (other.CompareTag("DeathTrap"))
        {
            // Εντοπισμός του GameManager και κάλεσμα του Game Over
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.TriggerGameOver();
            }

            // Προαιρετικά: Μπορείς να σταματήσεις την κίνηση του Bob ή να τον καταστρέψεις
            Destroy(gameObject);
        }
    }

    private IEnumerator ShrinkAndDestroy(GameObject collectible)
    {
        Vector3 originalScale = collectible.transform.localScale;
        float shrinkDuration = 1f;
        float time = 0;

        while (time < shrinkDuration)
        {
            if (collectible != null)
            {
                collectible.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, time / shrinkDuration);
                time += Time.deltaTime;
            }
            else
            {
                yield break;
            }

            yield return null;
        }

        if (collectible != null)
        {
            Destroy(collectible);
        }
    }
}
