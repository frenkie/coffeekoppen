using UnityEngine;

public class ProjectileCommands : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        this.SendMessageUpwards("OnLaunch");
    }
}