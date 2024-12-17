using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   public Text gameOverText; // Αναφορά στο GameOverText

    private bool isGameOver = false; // Έλεγχος αν το παιχνίδι έχει τερματίσει

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); // Βεβαιώσου ότι είναι ανενεργό στην αρχή
        }
    }

    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true; // Ορίζουμε ότι το παιχνίδι τερματίζει
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true); // Εμφάνιση του "Game Over"
            }
            Time.timeScale = 0; // Πάγωμα του παιχνιδιού
        }
    }
}