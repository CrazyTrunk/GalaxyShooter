using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField] float radius = 1.0f;
    [SerializeField] GameObject waypointPrefab;
    [SerializeField] private Transform currentTransform;

    public void Awake()
    {
        OnInit();
    }
    private void OnInit()
    {
        List<Vector3> hexagonPoints = CalculateHexagonPoints(currentTransform.position);
        for (int i = 0; i < hexagonPoints.Count; i++)
        {
            Instantiate(waypointPrefab, hexagonPoints[i], Quaternion.identity, currentTransform);
        }
    }
    public List<Vector3> CalculateHexagonPoints(Vector3 center)
    {
        float startAngle = 90 * Mathf.Deg2Rad;
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < 6; i++)
        {
            float angle = startAngle - i * 60 * Mathf.Deg2Rad;
            Vector3 currentPoint = new Vector3(center.x + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, 0);
            points.Add(currentPoint);

            float nextAngle = startAngle - ((i + 1) % 6) * 60 * Mathf.Deg2Rad;
            Vector3 nextPoint = new Vector3(center.x + Mathf.Cos(nextAngle) * radius, center.y + Mathf.Sin(nextAngle) * radius, 0);
            Vector3 midPoint = CalculateCenterPointBetweenVectors(currentPoint, nextPoint);
            points.Add(midPoint);
        }
        return points;
    }
    public Vector3 CalculateCenterPointBetweenVectors(Vector3 vector1, Vector3 vector2)
    {
        return (vector1 + vector2) / 2;
    }
}
