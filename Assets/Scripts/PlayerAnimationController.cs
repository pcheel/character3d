using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private PlayerJumping _playerJumping;
    private PlayerAttacking _playerAttacking;

    public void PlayMoveAnimation(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
    public void PlayJumpAnimation()
    {
        _animator.SetBool("Jump", true);
    }
    public void PlayAttackAnimation()
    {
        _animator.SetBool("Attack", true);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJumping = GetComponent<PlayerJumping>();
        _playerAttacking = GetComponent<PlayerAttacking>();
    }
    private void OnEnable() 
    {
        _playerMovement.OnMoveAction += PlayMoveAnimation;
        _playerJumping.OnJumpAction += PlayJumpAnimation;
        _playerAttacking.OnAttackAction += PlayAttackAnimation;
    }
    private void OnDisable() 
    {
        _playerMovement.OnMoveAction -= PlayMoveAnimation;
        _playerJumping.OnJumpAction -= PlayJumpAnimation;
        _playerAttacking.OnAttackAction -= PlayAttackAnimation;
    }
}
