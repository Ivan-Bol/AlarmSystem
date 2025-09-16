using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    [SerializeField] private MotionSensor _motionSensor;

    private void OnEnable()
    {
        _motionSensor.CrookEntered += TurnUpVolume;
        _motionSensor.CrookExited += TurnDownVolume;
    }

    private void OnDisable()
    {
        _motionSensor.CrookEntered -= TurnUpVolume;
        _motionSensor.CrookExited -= TurnDownVolume;
    }

    private void TurnUpVolume()
    {
        _alarmSystem.TurnUp(_alarmSystem.MaxVolume);
    }

    private void TurnDownVolume()
    {
        _alarmSystem.TurnDown(_alarmSystem.MinVolume);
    }
}
