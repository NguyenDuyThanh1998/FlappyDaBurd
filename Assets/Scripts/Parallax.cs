using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    #region Variable Declaration
    [SerializeField] Transform m_Background;
    [SerializeField] Transform m_Ground;
    [SerializeField] Vector3 m_BackgroundPosition;
    [SerializeField] Vector3 m_GroundPosition;
    //[SerializeField] Vector3 m_EulerAngles; // For future expansions.

    public Transform Background => m_Background;
    public Transform Ground => m_Ground;
    public Vector3 BackgroundPosition => m_BackgroundPosition;
    public Vector3 GroundPosition => m_GroundPosition;

    public float m_BackgroundParallaxIndex;
    public float m_GroundParallaxIndex;
    #endregion

    private void Awake()
    {
        m_BackgroundPosition = m_Background.position;
        m_GroundPosition = m_Ground.position;
    }

    private void Update()
    {
        
    }
}
