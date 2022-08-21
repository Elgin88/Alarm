using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private DoorCheckPoint _checkPoint;
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _currentVolume;
    [SerializeField] private float _targetVolume;
    [SerializeField] private float _speedOfChange;

    private float _timeAfterLastChange;
    private bool _isNeedChangeVolume = false;

    public void OnEnable()
    {
        _checkPoint.ThiefCrossPoint += EnableAlarm;
    }

    public void OnDisable()
    {
        _checkPoint.ThiefCrossPoint -= EnableAlarm;
    }

    public void FixedUpdate()
    {
        if (_isNeedChangeVolume == true)
        {
            _alarm.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _speedOfChange * _timeAfterLastChange * Time.deltaTime);
            _timeAfterLastChange += Time.deltaTime;
        }
    }

    private void EnableAlarm()
    {
        _alarm.Play();
        _isNeedChangeVolume = true;
        _currentVolume = 1;
        _timeAfterLastChange = 0;
    }
}
