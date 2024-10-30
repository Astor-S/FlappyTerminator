using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable<Enemy>
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _lifeTime = 40f;
    [SerializeField] private float _repeatShoot = 1f;

    private WaitForSeconds _waitLifeTime;
    private WaitForSeconds _waitRepeatShoot;

    public event Action<Enemy> Destroyed;

    private void OnEnable()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
        _waitRepeatShoot = new WaitForSeconds(_repeatShoot);
        StartCoroutine(DelayedDestroy());
        StartCoroutine(DelayedShoot());
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

    private IEnumerator DelayedShoot()
    {
        yield return _waitRepeatShoot;
        _shooter.Shoot();
    }
}