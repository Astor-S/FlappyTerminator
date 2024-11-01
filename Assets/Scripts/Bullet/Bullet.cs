using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IDestroyable<Bullet>
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lifeTime = 10f;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private WaitForSeconds _waitLifeTime;

    public event Action<Bullet> Destroyed;

    public float Damage => _damage;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
        StartCoroutine(DelayedDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(Damage);
        }
    }

    public void SetDirection(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
        _rigidbody2D.velocity = transform.right * _speed;
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
    }

    private IEnumerator DelayedDestroy()
    {
        yield return _waitLifeTime;
        Destroy();
    }
}