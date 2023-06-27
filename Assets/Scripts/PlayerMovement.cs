using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Movement
{
    [SerializeField] private float _speed;

    private Rigidbody _body;
    private Quaternion _lastRotation;
    private Vector3 _lastDirectionNotInJump;

    public Action<float> OnMoveAction;

    public override void Move(Vector3 direction) 
    {
        if (direction != Vector3.zero)
        {
            _body.rotation = direction.x >= 0f ? Quaternion.Euler(0f,Vector3.Angle(direction, Vector3.forward), 0f) : Quaternion.Euler(0f, -Vector3.Angle(direction, Vector3.forward), 0f);
            _lastRotation = _body.rotation;
        }
        else
        {
            _body.rotation = _lastRotation;
        }
        _lastDirectionNotInJump = direction;
        _body.velocity = direction * _speed;
        Debug.Log(_body.velocity);
        OnMoveAction?.Invoke(_body.velocity.magnitude);
    }
    public override void MoveInJump(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            _body.rotation = direction.x >= 0f ? Quaternion.Euler(0f,Vector3.Angle(direction, Vector3.forward), 0f) : Quaternion.Euler(0f, -Vector3.Angle(direction, Vector3.forward), 0f);
            _lastRotation = _body.rotation;
        }
        else
        {
            _body.rotation = _lastRotation;
        }
        direction = _lastDirectionNotInJump * _speed;
        direction.y = _body.velocity.y;
        _body.velocity = direction;
        OnMoveAction?.Invoke(_body.velocity.magnitude);
    }

    private void Awake() 
    {
        _body = GetComponent<Rigidbody>();
    }
}
