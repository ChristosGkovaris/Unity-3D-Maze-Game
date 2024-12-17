using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBob : MonoBehaviour
{
    public float speed = 5.0f;
    private float[] speedLevels = { 2f, 4f, 6f, 8f, 10f }; // Πέντε διαβαθμίσεις ταχύτητας
    private int currentSpeedIndex = 2; // Ξεκινάει από την τρίτη ταχύτητα (6f)

    public float minX = -45f, maxX = 45f; // Όρια στον άξονα X
    public float minZ = -45f, maxZ = 45f; // Όρια στον άξονα Z
    public LayerMask wallLayer; // Layer για τους τοίχους

    void Update()
    {
        // Έλεγχος για αλλαγή ταχύτητας
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSpeedIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSpeedIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentSpeedIndex = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentSpeedIndex = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5)) currentSpeedIndex = 4;

        // Ορισμός της τρέχουσας ταχύτητας
        speed = speedLevels[currentSpeedIndex];

        float moveX = 0, moveZ = 0;

        if (Input.GetKey(KeyCode.I)) moveZ = 3; // Προς τα μπροστά
        if (Input.GetKey(KeyCode.K)) moveZ = -3; // Προς τα πίσω
        if (Input.GetKey(KeyCode.J)) moveX = -3; // Αριστερά
        if (Input.GetKey(KeyCode.L)) moveX = 3; // Δεξιά

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Έλεγχος αν η νέα θέση συγκρούεται με τοίχους
        Vector3 checkBoxSize = new Vector3(3.5f, 3.5f, 3.5f); // Μέγεθος του ελέγχου (προσαρμοσμένο για τον Bob)
        if (!Physics.CheckBox(newPosition, checkBoxSize, Quaternion.identity, wallLayer))
        {
            // Περιορισμός θέσης στα όρια του λαβύρινθου
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            transform.position = newPosition;
        }
    }
}
