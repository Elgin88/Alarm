using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorCheckPoint : MonoBehaviour
{
    [SerializeField] private float _delay; 

    public event UnityAction ThiefCrossPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            ThiefCrossPoint?.Invoke();
        }
    }
}
