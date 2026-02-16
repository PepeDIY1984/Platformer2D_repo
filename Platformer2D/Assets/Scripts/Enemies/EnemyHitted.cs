using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHitted : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource sound;
    public GameObject particles;
    public SpriteRenderer mushroomSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            sound.Play();
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up*4;
            particles.SetActive(true);
            mushroomSprite.enabled = false;
            Destroy(enemy,0.2f); 
        }
    }
}
