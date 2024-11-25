using UnityEngine;
using PersonalLibrary.pUnity.pAttribute;

public abstract class Parallax : MonoBehaviour
{
    [SerializeField] [ReadOnly] protected MeshRenderer m_MeshRenderer;
    protected const float RATIO = 6; // Material's texture offset to Transform.position ratio.

    private void Awake()
    {
        GetMeshRenderer();
    }

    protected virtual void OnEnable() { }

    protected virtual void FixedUpdate() { }

    [ContextMenu("Get Mesh Renderer")]
    void GetMeshRenderer()
    {
        if (!m_MeshRenderer)
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }
    }

    protected virtual void Movement(float _parallaxIndex)
    {
        m_MeshRenderer.material.mainTextureOffset += _parallaxIndex * Time.fixedDeltaTime * Vector2.right;
    }
}
