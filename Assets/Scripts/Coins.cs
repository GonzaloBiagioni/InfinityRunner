using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float turnspeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IncrementScore();

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);
    }
}
