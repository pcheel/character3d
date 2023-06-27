using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private GroundedChecker _groundedChecker;
    [SerializeField] private Player _player;

    private IPlayerState _playerState;

    public void HandleMoveInput(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        IPlayerState state = _playerState.Move(moveDirection);
        CheckStateChanging(state);
    }
    public void HandleJumpInput()
    {
        IPlayerState state = _playerState.Jump();
        CheckStateChanging(state);
    }
    public void HandleAttackInput()
    {
        IPlayerState state = _playerState.Attack();
        CheckStateChanging(state);
    }
    public void HandleGroudedStateChanging(bool isGrounded)
    {
        _playerState = isGrounded ? new PlayerIdleState(_player) : new PlayerJumpingState(_player);
    }

    private void OnEnable() 
    {
        _joystick.OnDragAction += HandleMoveInput;
        _groundedChecker.OnChangeGroundedStateAction += HandleGroudedStateChanging;
    }
    private void OnDisable()
    {
        _joystick.OnDragAction -= HandleMoveInput;
        _groundedChecker.OnChangeGroundedStateAction -= HandleGroudedStateChanging;
    }
    private void CheckStateChanging(IPlayerState playerState)
    {
        if (playerState != null)
        {
            _playerState = playerState;
        }
    }
    private void Awake() 
    {
        _playerState = new PlayerIdleState(_player);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
