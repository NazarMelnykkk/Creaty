using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveHandler : MonoBehaviour, ICommandHandler
{
    private Rigidbody _rigidbody;

    private float _moveSpeed = 5f;

    private Command _command;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ProcessCommand(Command command)
    {
        _command = command;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _command.Point);

        if (distanceToTarget <= 0.1f)
        {
            _command.IsComplete = true;
            _rigidbody.velocity = Vector3.zero; 
            return;
        }

        Vector3 direction = (_command.Point - transform.position).normalized;
        _rigidbody.velocity = direction * _moveSpeed;

    }
}
