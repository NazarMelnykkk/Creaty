using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TimerView _timerView;
    [SerializeField] private float _remainingTime;

    private Coroutine _timerCoroutine;
    private float _delay = 1f;

    private void OnEnable()
    {
        GameEventHandler.Instance.MiscEvents.OnPlayerMoveEvent += StartTimer;
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent += StopTimer;
    }

    private void OnDisable()
    {
        GameEventHandler.Instance.MiscEvents.OnPlayerMoveEvent -= StartTimer;
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent -= StopTimer;
    }

    private void StartTimer()
    {
        GameEventHandler.Instance.MiscEvents.OnPlayerMoveEvent -= StartTimer;

        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }
        Debug.Log("Timer");
        _timerCoroutine = StartCoroutine(Timer());
    }

    private void StopTimer()
    {
        GameEventHandler.Instance.MiscEvents.OnAllCollectKeysCompleteEvent -= StopTimer;

        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }
    }

    private IEnumerator Timer()
    {
        while (_remainingTime >= 0)
        {
            _timerView.SetTime(_remainingTime);
            yield return new WaitForSeconds(_delay);
            _remainingTime--;
        }

        GameEventHandler.Instance.MiscEvents.TimerLeft();
        _timerCoroutine = null;
    }

}
