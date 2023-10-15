using UnityEngine;

public abstract class Parallax : MonoBehaviour
{
    [SerializeField] [ReadOnly] protected MeshRenderer m_MeshRenderer;

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

    protected void Movement(float _parallaxIndex)
    {
        m_MeshRenderer.material.mainTextureOffset += _parallaxIndex * Time.deltaTime * Vector2.right;
    }
}
