using UnityEngine;

public class EnemyJuan : MonoBehaviour
{

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.Play("enemyJuan");
    }

}


