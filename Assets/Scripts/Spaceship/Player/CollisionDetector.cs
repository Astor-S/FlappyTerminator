using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action DeadlyCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            DeadlyCollide?.Invoke();

        if (collision.gameObject.TryGetComponent<Enemy>(out _))
            DeadlyCollide?.Invoke();
    }
}