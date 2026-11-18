using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;                 
            gameObject.transform.GetChild(0).gameObject.SetActive(true);    
            Destroy(gameObject, 0.5f);                                      
            GetComponent<Collider2D>().enabled = false;
            SceneController.fruitsCollected++;                              
            GameObject.Find("GameManager").GetComponent<SceneController>().checkFruitsRemaining();

            sound.Play(); 
        }
    }

}
