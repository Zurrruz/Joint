using UnityEngine;

public class CatapultState
{
    public Vector3 HighAnchor { get; } = new Vector3(0, 5, -0.1f);
    public Vector3 LowAnchor { get; } = new Vector3(0, 0, 0.35f);
    public Vector3 CurrentAnchor { get; set; }
}
