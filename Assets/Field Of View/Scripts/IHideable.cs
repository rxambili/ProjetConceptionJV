using UnityEngine;
/// <summary>
/// Interface that needs to be implemented by any object that gets affected by the Field of View of the player.
/// </summary>
public abstract class IHideable : MonoBehaviour{
    public bool isInFov = false;
    public virtual void OnFOVEnter()
    {
        isInFov = true;
    }
    public virtual void OnFOVLeave()
    {
        isInFov = false;
    }
}
