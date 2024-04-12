using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMoveEvent : MonoBehaviour
{
    private void OnEnable()
    {
        InputController.Instance.OnMoveDirectionButtonPerformedEvent += MoveEvent;
    }

    private void OnDisable()
    {
        InputController.Instance.OnMoveDirectionButtonPerformedEvent -= MoveEvent;
    }

    private void MoveEvent(Vector2 d)
    {
        GameEventHandler.Instance.MiscEvents.PlayerMoveEvent();
        gameObject.SetActive(false);
    }
}
