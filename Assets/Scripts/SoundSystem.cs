using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _sounds;
    private AudioSource _audioSource => gameObject.GetComponent<AudioSource>();

    public void PlaySound(Sound clip)
    {
        _audioSource.clip = _sounds[(int)clip];
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
}

public enum Sound
{
    StartSound,
    BallTouch,
    FinishSound
}
