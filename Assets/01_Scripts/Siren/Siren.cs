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
    [SerializeField] private float _duration;

    private float _timeToChange;

    public void OnEnable()
    {
        _checkPoint.ThiefCrossPoint += EnableAlarm;
    }

    public void OnDisable()
    {
        _checkPoint.ThiefCrossPoint -= EnableAlarm;
    }    

    private void EnableAlarm()
    {       
        _alarm.Play();
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_timeToChange < _duration)
        {
            _alarm.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _speedOfChange * Time.deltaTime * _timeToChange);
            _timeToChange += Time.deltaTime;           

            yield return null;
        }

        Debug.Log("Here");

        _timeToChange = 0;
        _alarm.Stop();
        _alarm.volume = _currentVolume;
        StopCoroutine(ChangeVolume());
    }
}
