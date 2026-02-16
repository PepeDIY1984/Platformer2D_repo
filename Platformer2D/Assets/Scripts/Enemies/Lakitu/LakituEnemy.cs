using UnityEngine;

public class LakituEnemy : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Follow")]
    public Vector2 followOffset = new Vector2(3f, 2f); // posición relativa al player
    public float followSmooth = 6f;                    // suavidad

    [Header("Float/Bob")]
    public float bobAmplitude = 0.15f;
    public float bobSpeed = 2.5f;

    [Header("Shoot")]
    public Transform shootPoint;
    public GameObject projectilePrefab;
    public float shootInterval = 2.0f;
    public float shootIntervalJitter = 0.6f; // variación aleatoria
    public float projectileSpeed = 7f;

    [Header("Facing")]
    public SpriteRenderer sr; // arrastra el SpriteRenderer aquí (o lo coge solo)

    float nextShootTime;

    void Awake()
    {
        if (!sr) sr = GetComponent<SpriteRenderer>();
        ScheduleNextShot();
    }

    void Update()
    {
        if (!player) return;

        // 1) Decide a qué lado del player se queda (mantener distancia horizontal)
        float side = (transform.position.x >= player.position.x) ? 1f : -1f;

        // 2) Posición objetivo con offset + flotación
        Vector3 target = player.position + new Vector3(followOffset.x * side, followOffset.y, 0f);
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmplitude;
        target.y += bob;

        // 3) Movimiento suave
        transform.position = Vector3.Lerp(transform.position, target, 1f - Mathf.Exp(-followSmooth * Time.deltaTime));

        // 4) Flip mirando al player (opcional)
        if (sr) sr.flipX = (player.position.x < transform.position.x);

        // 5) Disparo
        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            ScheduleNextShot();
        }
    }

    void ShootAtPlayer()
    {
        GameObject p = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        var proj = p.GetComponent<Projectile2D>();
        proj.Launch(player);
    }

    void ScheduleNextShot()
    {
        float jitter = Random.Range(-shootIntervalJitter, shootIntervalJitter);
        nextShootTime = Time.time + Mathf.Max(0.2f, shootInterval + jitter);
    }
}
