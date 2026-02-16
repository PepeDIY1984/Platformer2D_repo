using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    public float upSpeed = 6f;
    public float upTime = 0.25f;
    public float chaseSpeed = 7f;

    Rigidbody2D rb;
    Transform target;
    float timer;
    bool chasing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Transform player)
    {
        target = player;

        // Fase 1 — impulso hacia arriba
        rb.linearVelocity = Vector2.up * upSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Cambiar a fase persecución
        if (!chasing && timer >= upTime && target != null)
        {
            chasing = true;

            Vector2 dir = (target.position - transform.position).normalized;
            rb.linearVelocity = dir * chaseSpeed;
        }
    }
}

public interface IDamageable
{
    void TakeDamage(int amount);
}
