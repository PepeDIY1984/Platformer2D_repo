using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeDirection : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.GetComponent<EnemyMoveForward>().speed = -enemy.GetComponent<EnemyMoveForward>().speed;
        enemy.GetComponent<SpriteRenderer>().flipX = !enemy.GetComponent<SpriteRenderer>().flipX;


        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Ay! " + collision.gameObject);
            Debug.Log("el objeto: " + collision.gameObject + " se ha hecho daño");
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<PlayerRespawn>().PlayerDamaged();

        }
    }
}
