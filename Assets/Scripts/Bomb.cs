using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private AudioSource sliceSound;
    private void Awake()
    {
        sliceSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sliceSound.Play();

            FindObjectOfType<GameManager>().Explode();           
        }
    }
}
