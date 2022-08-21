using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _patrolPoints;
    private Animator _animator;
    private string _moveUp = "Up";
    private string _moveDown = "Down";
    private string _moveLeft = "Left";
    private string _moveRight = "Right";

    private int _currentPointNumber;    

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _patrolPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _patrolPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {        
        Transform target = _patrolPoints[_currentPointNumber];        

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        PlayWalkingAnimation();

        if (transform.position == target.position)
            _currentPointNumber++;

        if (_currentPointNumber == _patrolPoints.Length - 1)
            _currentPointNumber = 0;  
    }

    private void PlayWalkingAnimation()
    {
        if (transform.position.x > _patrolPoints[_currentPointNumber].position.x)
        {
            _animator.Play(_moveLeft);
        }
        else if (transform.position.x < _patrolPoints[_currentPointNumber].position.x)
        {
            _animator.Play(_moveRight);
        }
        else if(transform.position.y > _patrolPoints[_currentPointNumber].position.y)
        {
            _animator.Play(_moveDown);
        }
        else if(transform.position.y < _patrolPoints[_currentPointNumber].position.y )
        {
            _animator.Play(_moveUp);
        }
    }
}
