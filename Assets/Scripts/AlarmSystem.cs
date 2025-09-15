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

    public void Signalize(float target)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(target));
    }

    private IEnumerator ChangeVolume(float target)
    {
        bool isWork = true;
        
        while (isWork)
        {
            if (_audioSource.volume == target)
            {
                yield break;
            }
            else
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
