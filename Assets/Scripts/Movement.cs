using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public abstract void Move(Vector3 direction);
    public abstract void MoveInJump(Vector3 direction);
}
