using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}