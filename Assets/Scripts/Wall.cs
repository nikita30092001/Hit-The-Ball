using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Camera _camera;

    public event Action OnWallsContact;

    private void Awake()
    {
        MoveWall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnWallsContact?.Invoke();
    }

    private void MoveWall()
    {
        var halfHeight = _camera.orthographicSize;
        var halfWidth = halfHeight * _camera.aspect;
        var center = (Vector2)_camera.transform.position;
        gameObject.transform.position = center + _direction * halfWidth;
    }
}
