using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    private float _minValue = 0;

    public event Action<float, float> ValueChanged;
    public event Action Died;
    
    public float Value { get; private set; }
    public float MaxValue => _maxValue;
    public bool IsAlive => Value > 0;

    private void Start()
    {
        Value = MaxValue;
    }

    public void Reduce(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        float newHealth = Mathf.Max(Value - damage, _minValue);
        UpdateValue(newHealth);

        if (IsAlive == false)
            ApplyDeath();
    }

    private void UpdateValue(float value)
    {
        Value = value;
        ValueChanged?.Invoke(value, _maxValue);
    }

    private void ApplyDeath()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}