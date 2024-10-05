using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Controller>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            FindObjectOfType<AudioManager>().Play("Win");
            Debug.Log("You Won!");
        }
    }
}


