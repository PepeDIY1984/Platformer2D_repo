using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int maxHp = 3;
    int hp;

    void Awake() => hp = maxHp;

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Player HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log("Player muerto");
            // aquí: respawn, animación, cargar escena, etc.
        }
    }
}
