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
    MeshRenderer[] m_Renderers;
    [SerializeField] Vector3 m_StartPosition;
    [SerializeField] float m_Width;
    //[SerializeField] float m_Height; // For future innovations.

    // public
    public Transform Transform => m_Transform;
    public Vector3 Position => m_Position;
    public float ParallaxIndex => m_ParallaxIndex;
    #endregion

    private void Awake()
    {
        Initialize();
        if (m_Transform.childCount > 0)
        {
            m_HasChild = true;
            m_Renderers = GetComponentsInChildren<MeshRenderer>();
            GetSize();
        }
    }

    void Initialize()
    {
        m_Transform = transform;
        m_Position = m_Transform.position;
        m_Width = 0;
        //m_Height = 0;

        //
        m_HasChild = false;
        //m_Loop = true;
    }

    void GetSize()
    {
        foreach (MeshRenderer renderer in m_Renderers)
        {
            m_Width += renderer.bounds.size.x;
            //m_Height += renderer.bounds.size.y;
        }
    }

    private void OnEnable()
    {
        m_StartPosition = m_Position;
    }

    private void Update()
    {
        CheckLooping();
        m_Transform.position = GetPosition();
    }

    Vector3 GetPosition()
    {
        var distance = m_ParallaxIndex * Time.deltaTime;
        m_Position.x -= distance;
        return m_Position;
    }

    void CheckLooping()
    {
        if (m_Loop /*&& m_HasChild*/)
        {
            //var limit = (m_Width - m_StartPosition.x)
        }
    }
}
