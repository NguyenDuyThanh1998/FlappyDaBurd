using FlappyDaBurd.Core;
using UnityEngine;

public abstract class Parallax : MonoBehaviour
{
    #region Variable Declaration
    // local
    [SerializeField] [ReadOnly] protected Transform m_Transform;
    [SerializeField] [ReadOnly] protected Vector3 m_Position;
    //[SerializeField] Vector3 m_EulerAngles; // For future expansions.

    [SerializeField] Renderer[] m_Renderers;
    [SerializeField] [ReadOnly] float m_Width;
    [SerializeField] [ReadOnly] float m_HalfCameraWidth;
    //[SerializeField] [ReadOnly] float m_Height; // For future innovations.
    //[SerializeField] [ReadOnly] float m_HalfCameraHeight;


    // public
    public Transform Transform => m_Transform;
    public Vector3 Position => m_Position;
    #endregion

    virtual protected void Awake()
    {
        Initialize();
    }

    abstract protected void OnEnable();

    abstract protected void FixedUpdate();

    [ContextMenu("Initialize")]
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
        m_Position = m_Transform.position;

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

    [ContextMenu("Set Center")]
    void SetCenter()
    {
        // Set center to match pivot. Or alternatively write a dif script to rearrange child position.
    }

    void GetCameraHalfWidth()
    {
        var MainCam = Camera.main;
        m_HalfCameraWidth = MainCam.orthographicSize * MainCam.aspect; // MainCam.orthographicSize is half the size of camera height * aspect ratio to get width.
    }

    protected Vector3 GetPosition(float _parallaxIndex)
    {
        //var lastSpriteSize = m_Renderers[^1].bounds.size;
        var travelLimit = (m_Width / 2f - m_HalfCameraWidth) + m_Position.x;
        if (travelLimit > 0)
        {
            var distance = _parallaxIndex * Time.deltaTime;
            m_Position.x -= distance;
        }
        else
        {
            //m_Position.x += m_Width - m_HalfCameraWidth * 2; // Left edge of last sprite match left edge camera bound.

            m_Position.x += m_Width * (1f - ( 1f / m_Renderers.Length)); // Right edge of last sprite match right edge camera bound.
        }
        return m_Position;
    }
}
