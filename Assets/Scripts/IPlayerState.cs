using System.Collections;
using UnityEngine;

public interface IPlayerState
{
    public IPlayerState Move(Vector3 direction);
    public IPlayerState Jump();
    public IPlayerState Attack();
}
