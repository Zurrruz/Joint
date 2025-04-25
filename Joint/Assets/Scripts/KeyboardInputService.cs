using UnityEngine;

public class KeyboardInputService : IInputService
{
    public bool IsChangeToHighAnchorPressed() => Input.GetKeyDown(KeyCode.Q);
    public bool IsChangeToLowAnchorPressed() => Input.GetKeyDown(KeyCode.R);
    public bool IsRockingPressed() => Input.GetKeyDown(KeyCode.Space);
}
