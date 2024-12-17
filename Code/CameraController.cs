using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20f; // Ταχύτητα κίνησης της κάμερας
    public float rotationSpeed = 85f; // Ταχύτητα περιστροφής της κάμερας

    void Update()
    {
        // Κίνηση στους άξονες X και Z
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Κίνηση στον άξονα Y (ύψος)
        float moveY = 0f;
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            moveY = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
        {
            moveY = -moveSpeed * Time.deltaTime;
        }

        // Εφαρμογή της κίνησης
        transform.Translate(new Vector3(moveX, moveY, moveZ), Space.World);

         // Περιστροφή γύρω από τον εαυτό της (άξονας Y και άλλοι)
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self); // Περιστροφή γύρω από τον Y άξονα
        }
    }
}

