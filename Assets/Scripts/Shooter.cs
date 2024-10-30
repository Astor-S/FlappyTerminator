using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _cooldown = 1f;

    private WaitForSeconds _waitCooldown;

    private bool _canShoot = true;

    private void OnEnable()
    {
        _waitCooldown = new WaitForSeconds(_cooldown);
    }

    public void Shoot()
    {
        if (_canShoot == false)
            return;

        _canShoot = false;

        Vector3 direction = transform.rotation.eulerAngles; 
        Bullet bullet = _bulletSpawner.Spawn(transform.position);
        bullet.SetDirection(direction);
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return _waitCooldown;
        _canShoot = true;
    }
}