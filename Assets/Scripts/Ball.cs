using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private Camera _camera;
    [SerializeField, Range(10, 15)] private int _offset;
    [SerializeField, Range(5, 10)] private int _torqueOffset;

    public Rigidbody2D _rigidbody { get; private set; }

    public event Action OnBallMoved;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var touchPosition = eventData.position;
        _soundSystem.PlaySound(Sound.BallTouch);
        MoveBall(touchPosition);
        OnBallMoved?.Invoke();
    }

    private void MoveBall(Vector2 touchPosition)
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        touchPosition = _camera.ScreenToWorldPoint(touchPosition, Camera.MonoOrStereoscopicEye.Mono);
        var forceVector = new Vector2(transform.position.x - touchPosition.x, 1);
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.AddTorque(-forceVector.normalized.x * _torqueOffset, ForceMode2D.Impulse);
        _rigidbody.AddForce(forceVector.normalized * _offset, ForceMode2D.Impulse);
    }
}
