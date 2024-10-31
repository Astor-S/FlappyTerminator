using UnityEngine;

public class EnemyBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
        }
    }
}