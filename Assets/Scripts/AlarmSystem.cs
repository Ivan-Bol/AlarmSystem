using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _speed;

    private AudioSource _audioSource;
    private Coroutine _coroutine;

    public float MinVolume => _minVolume;
    public float MaxVolume => _maxVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TurnUp(float target)
    {
        TryTurnOff();

        _audioSource.Play();
        _coroutine = StartCoroutine(ChangeVolume(target));
    }

    public void TurnDown(float target)
    {
        TryTurnOff();

        _coroutine = StartCoroutine(ChangeVolume(target));
    }

    private void TryTurnOff()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);
            
            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
