using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapCollision : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Υποθέτουμε ότι ο Bob έχει tag "Player"
        {
            // Κάλεσε το Game Over
            FindObjectOfType<GameManager>().TriggerGameOver();

            // Καταστροφή του Bob
            Destroy(other.gameObject);
        }
    }
}


