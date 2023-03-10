using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    #region Variable Declaration
    // local
    [SerializeField] Transform m_Transform;
    [SerializeField] Vector3 m_Position;
    //[SerializeField] Vector3 m_EulerAngles; // For future expansions.
    [SerializeField] float m_ParallaxIndex;

    [SerializeField] Renderer[] m_Renderers;
    [SerializeField] float m_Width;
    //[SerializeField] float m_Height; // For future innovations.
    [SerializeField] float m_HalfCameraWidth;

    // public
    public Transform Transform => m_Transform;
    public Vector3 Position => m_Position;
    public float ParallaxIndex => m_ParallaxIndex;
    #endregion

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        SetDefaultValues();
        GetSumSize();
        SetCenter();
        GetCameraHalfWidth();
    }

    void SetDefaultValues()
    {
        m_Transform = transform;

        m_Width = 0;
        //m_Height = 0;
    }

    void GetSumSize()
    {
        if (m_Transform.childCount > 0)
        {
            m_Renderers = GetComponentsInChildren<Renderer>();
        }
        else
        {
            m_Renderers = GetComponents<Renderer>();
        }
        GetSize();
    }

    void GetSize()
    {
        foreach (var renderer in m_Renderers)
        {
            //Debug.Log(renderer.bounds.size);
            m_Width += renderer.bounds.size.x;
            //m_Height += renderer.bounds.size.y;
        }
    }

    void GetCameraHalfWidth()
    {
        var MainCam = Camera.main;
        m_HalfCameraWidth = MainCam.orthographicSize * MainCam.aspect; // MainCam.orthographicSize is camera height * aspect ratio to get width.
    }

    private void OnEnable()
    {
        m_Position = m_Transform.position;
    }

    private void Update()
    {
        m_Transform.position = GetPosition();
    }

    Vector3 GetPosition()
    {
        //var lastSpriteSize = m_Renderers[^1].bounds.size;
        var travelLimit = (m_Width / 2f - m_HalfCameraWidth) + m_Position.x;
        if (travelLimit > 0)
        {
            var distance = m_ParallaxIndex * Time.deltaTime;
            m_Position.x -= distance;
        }
        else
        {
            //m_Position.x += m_Width - m_HalfCameraWidth * 2; // Left edge of last sprite match left edge camera bound.

            m_Position.x += m_Width * (1f - ( 1f / m_Renderers.Length)); // Right edge of last sprite match right edge camera bound.
        }
        return m_Position;
    }

    #region Context Menu
    [ContextMenu("Init")]
    void SetCenter()
    {
        // Set center to match pivot. Or alternatively write a dif script to rearrange child position.
    }
    #endregion
}
