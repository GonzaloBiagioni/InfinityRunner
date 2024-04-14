using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int desiredLine = 1;
    public float roadDistance = 2.5f;
    public float lerpAmount = 20;
    public float jumpForce = 4;
    private bool isJumping;
    public Rigidbody rb;
    public float forwardSpeed = 5f; // Velocidad hacia adelante

    void Update()
    {
        // Mover hacia adelante
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLine++;
            if (desiredLine == 3)
            {
                desiredLine = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLine--;
            if (desiredLine == -1)
            {
                desiredLine = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
            isJumping = true;
        }

        Vector3 roadPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLine == 0)
        {
            roadPosition += Vector3.left * roadDistance;
        }
        else if (desiredLine == 2)
        {
            roadPosition += Vector3.right * roadDistance;
        }

        transform.position = Vector3.Lerp(transform.position, roadPosition, lerpAmount * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }

    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}