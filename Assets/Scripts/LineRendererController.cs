using Unity.Mathematics;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform origin;
    [SerializeField] private GameDataSO gameData;

    [Header("Projection Values")]
    [SerializeField] private float simulationTime = 5f;
    [SerializeField] private float step = 0.1f;

    public void DrawBallTrajectory(Vector3 velocity)
    {
        int pointCount = Mathf.CeilToInt(simulationTime / step);
        line.positionCount = pointCount;
        for (int i = 0; i < pointCount; i++)
        {
            float t = i * step;
            Vector3 position = origin.position + (velocity * t) + (0.5f * new Vector3(gameData.Acceleration.x, gameData._gravity + gameData.Acceleration.y, gameData.Acceleration.z) * math.pow(t, 2));
            line.SetPosition(i, position);
        }
    }
}
