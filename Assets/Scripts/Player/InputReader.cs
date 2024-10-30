using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootKey = KeyCode.X;

    public event Action Jumped;
    public event Action Shooted;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
            Jumped?.Invoke();

        if (Input.GetKey(_shootKey))
            Shooted?.Invoke();    
    }
}