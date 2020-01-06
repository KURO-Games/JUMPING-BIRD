using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpecialSkill : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    [SerializeField]
    private float m_radius = 0;
    [SerializeField]
    private float m_lineWidth = 0;

    [SerializeField]
    private float m_duration = 0;
    [SerializeField]
    private float m_from = 0;
    [SerializeField]
    private float m_to = 0;

    private float m_elapedTime;

    // Start is called before the first frame update
    void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        InitLine();
    }

    // Update is called once per frame
    void Update()
    {
        m_elapedTime += Time.deltaTime;

        var amout = m_elapedTime % m_duration / m_duration;
        var scale = Mathf.Lerp(m_from, m_to, amout);

        transform.localScale = new Vector3(scale, scale, 1);
        Destroy(gameObject, m_duration);
    }

    private void InitLine()
    {
        var segments = 360;

        m_lineRenderer.startWidth = m_lineWidth;
        m_lineRenderer.endWidth = m_lineWidth;
        m_lineRenderer.positionCount = segments;
        m_lineRenderer.loop = true;
        m_lineRenderer.useWorldSpace = false;

        var points = new Vector3[segments * 2];
        var points2 = new Vector3[segments * 2];

        for (int i = 0; i < segments; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            var x = Mathf.Sin(rad) * m_radius;
            var y = Mathf.Cos(rad) * m_radius;
            points[i] = new Vector3(x, y, 0);
        }

        for (int i = 0; i < segments; i++)
        {

            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            var x = Mathf.Sin(rad) * m_radius / 2;
            var y = Mathf.Cos(rad) * m_radius / 2;
            points2[i] = new Vector3(x, y, 0);
        }
        m_lineRenderer.SetPositions(points);
    }
}
