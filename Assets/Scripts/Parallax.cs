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

    [SerializeField] bool m_HasChild = false;
    [SerializeField] bool m_Loop = true;
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
        GetCameraHalfWidth();
    }

    void SetDefaultValues()
    {
        m_Transform = transform;

        m_Width = 0;
        //m_Height = 0;

        m_HasChild = false;
        //m_Loop = true;
    }

    void GetSumSize()
    {
        if (m_Transform.childCount > 0)
        {
            m_HasChild = true;
            m_Renderers = GetComponentsInChildren<Renderer>();
            GetSize();
        }
        else
        {
            m_Renderers = GetComponents<Renderer>();
            GetSize();
        }
    }

    void GetSize()
    {
        foreach (var renderer in m_Renderers)
        {
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
        var travelLimit = (m_Width / 2 - m_HalfCameraWidth) + m_Position.x;
        if (travelLimit > 0)
        {
            var distance = m_ParallaxIndex * Time.deltaTime;
            m_Position.x -= distance;
        }
        else if (travelLimit <= 0 && m_Loop == false)
        {
            m_Position.x += m_Width - m_HalfCameraWidth * 2;
        }
        return m_Position;
    }
}
