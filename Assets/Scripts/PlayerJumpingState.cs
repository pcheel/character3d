using UnityEngine;

public class PlayerJumpingState : IPlayerState
{
    private Player _player;
    public PlayerJumpingState(Player player)
    {
        _player = player;
    }
    public IPlayerState Attack()
    {
        return null;
    }
    public IPlayerState Jump()
    {
        return null;
    }
    public IPlayerState Move(Vector3 direction)
    {
        _player.MoveInJump(direction);
        return null;
    }
}
