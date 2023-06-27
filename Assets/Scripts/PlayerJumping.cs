using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider))]
public class PlayerJumping : Jumping
{
    [SerializeField] private Vector3 _colliderCenterInJump;
    [SerializeField] private Vector3 _colliderCenterNotInJump;
    [SerializeField] private Vector3 _colliderSizeInJump;
    [SerializeField] private Vector3 _colliderSizeNotInJump;
    [SerializeField] private BoxCollider _checkGroundBox;

    private BoxCollider _boxCollider;
    private Rigidbody _body;
    private bool _lerpColliderUp;
    private bool _lerpColliderDown;
    private float _counter;
    private const float FIRST_JUMP_STATE_DURATION = 0.3f;
    private const float SECOND_JUMP_STATE_DURATION = 0.4f;
    private const float THIRD_JUMP_STATE_DURATION = 0.4f;


    public Action OnJumpAction;

    public override void Jump()
    {
        _body.useGravity = false;
        OnJumpAction?.Invoke();
        StartCoroutine(JumpStates());
    }

    private IEnumerator JumpStates()
    {
        _checkGroundBox.center = new Vector3(0f,0.3f, 0f);
        yield return new WaitForSeconds(FIRST_JUMP_STATE_DURATION);
        _lerpColliderUp = true;
        _counter = 0f;
        yield return new WaitForSeconds(SECOND_JUMP_STATE_DURATION);
        _lerpColliderDown = true;
        _lerpColliderUp = false;
        _counter = 0f;
        yield return new WaitForSeconds(THIRD_JUMP_STATE_DURATION);
        _body.useGravity = true;
        _lerpColliderUp = false;
        _checkGroundBox.center = Vector3.zero;
    }
    private void Awake() 
    {
        _boxCollider = GetComponent<BoxCollider>();
        _body = GetComponent<Rigidbody>();
        _counter = 0f;
    }
    private void FixedUpdate() 
    {
        if (_lerpColliderUp)
        {
            _counter += Time.fixedDeltaTime;
            float i = _counter / SECOND_JUMP_STATE_DURATION;
            _boxCollider.size = Vector3.Lerp(_colliderSizeNotInJump, _colliderSizeInJump, i);
            _boxCollider.center = Vector3.Lerp(_colliderCenterNotInJump, _colliderCenterInJump, i);
        }
        else if (_lerpColliderDown)
        {
            _counter += Time.fixedDeltaTime;
            float i = _counter / THIRD_JUMP_STATE_DURATION;
            _boxCollider.size = Vector3.Lerp(_colliderSizeInJump, _colliderSizeNotInJump, i);
            _boxCollider.center = Vector3.Lerp(_colliderCenterInJump, _colliderCenterNotInJump, i);
        }
    }
}
