using UnityEngine;

public class EnemyKnife : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.Play("enemyKnife");
    }

}
