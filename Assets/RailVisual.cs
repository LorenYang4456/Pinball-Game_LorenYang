using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RailVisual : MonoBehaviour
{
    public Transform[] waypoints;

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        DrawRail();
    }

    private void DrawRail()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        line.positionCount = waypoints.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            line.SetPosition(
                i,
                waypoints[i].position
            );
        }
    }
}