using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private Player _player;
    public PlayerIdleState(Player player)
    {
        _player = player;
    }
    public IPlayerState Attack()
    {
        _player.Attack();
        return null;
    }
    public IPlayerState Jump()
    {
        _player.Jump();
        return new PlayerJumpingState(_player);
    }
    public IPlayerState Move(Vector3 direction)
    {
        _player.Move(direction);
        return new PlayerMovementState(_player);
    }
}
