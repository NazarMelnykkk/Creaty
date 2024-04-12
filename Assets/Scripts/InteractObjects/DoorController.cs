using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private float _openingDistance = 3;
    private float _speed = 0.5f;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;

    private void OnEnable()
    {
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent += Open;
    }

    private void Start()
    {
        _initialPosition = transform.position;
        _targetPosition = _initialPosition + Vector3.up * _openingDistance;
    }

    private void OnDisable()
    {
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent -= Open;
    }

    private void Open()
    {
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent -= Open;
        StartCoroutine(MoveCoroutine());    
    }

    private IEnumerator MoveCoroutine()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= 1f) 
        {
            float time = (Time.time - startTime) * _speed;
            transform.position = Vector3.Lerp(_initialPosition, _targetPosition, time);
            yield return null;
        }
    }



}
