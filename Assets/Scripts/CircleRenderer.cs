using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    [Range(20,49)]
    public int segments;
    public float r;
    LineRenderer line;

    void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
    }

    public void ChangeColor(Color col)
    {
        line.startColor = col;
        line.endColor = col;
    }

    public void CreatePoints()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * r;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * r;

            line.SetPosition(i, new Vector3(x, y, 0f));

            angle += (360f / segments);
        }
    }
}