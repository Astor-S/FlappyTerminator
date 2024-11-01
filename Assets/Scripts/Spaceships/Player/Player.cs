using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private InputReader _inputReader;
    
    private Mover _mover;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    public void Reset()
    {
        _mover.Reset();
    }

    private void AddListeners()
    {
        _collisionDetector.DeadlyCollide += GameOver;
        _inputReader.Jumped += OnJump;
        _inputReader.Shooted += OnShoot;
    }

    private void RemoveListeners()
    {
        _collisionDetector.DeadlyCollide -= GameOver;
        _inputReader.Jumped -= OnJump;
        _inputReader.Shooted -= OnShoot;
    }

    private void OnJump()
    {
        _mover.Jump();
    }

    private void OnShoot()
    {
        _shooter.Shoot();
    }

    public void TakeDamage(float damage)
    {
       _health.Reduce(damage);
    }
}