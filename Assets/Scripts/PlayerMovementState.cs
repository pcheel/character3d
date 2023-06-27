using UnityEngine;

public class PlayerMovementState : IPlayerState
{
    private Player _player;
    public PlayerMovementState(Player player)
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
        return null;
    }
}
