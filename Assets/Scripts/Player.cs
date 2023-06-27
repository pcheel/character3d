using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement _movement;
    private Jumping _jumping;
    private Attacking _attacking;

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
    public void MoveInJump(Vector3 direction)
    {
        _movement.MoveInJump(direction);
    }
    public void Jump()
    {
        _jumping.Jump();
    }
    public void Attack()
    {
        _attacking.Attack();
    }

    private void Awake() 
    {
        _movement = GetComponent<Movement>();
        _jumping = GetComponent<Jumping>();
        _attacking = GetComponent<Attacking>();
    }
}
