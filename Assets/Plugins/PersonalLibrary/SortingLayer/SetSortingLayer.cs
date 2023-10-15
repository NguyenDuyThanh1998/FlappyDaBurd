#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[ExecuteAlways]
[HasSortingLayer("m_SortingLayer")]
public class SetSortingLayer : MonoBehaviour
{
	[SerializeField] [ReadOnly] Renderer m_Renderer;
	[SerializeField] [ReadOnly] string m_SortingLayer;
	[Space(10)]
	[SerializeField] int m_SortingOrderInLayer;

	// Cache
	string cachedSortingLayer;
	int cachedSortingOrder;

	// Public
	public string SortingLayer => m_SortingLayer;
	public int SortingOrder => m_SortingOrderInLayer;

	void Start()
	{
		GetRenderer();
		SetLayer();
	}

	private void Update()
    {
		if (EditorApplication.isPlaying) 
			return;
		else
        {
			//Debug.Log("Checking");
			if (m_SortingLayer != cachedSortingLayer || m_SortingOrderInLayer != cachedSortingOrder)
			{
				SetLayer();
				//Debug.Log("Updated");
			}
		}
	}

	public void SetLayer()
	{
		m_Renderer.sortingLayerName = m_SortingLayer;
		m_Renderer.sortingOrder = m_SortingOrderInLayer;
		
		cachedSortingLayer = m_Renderer.sortingLayerName;
		cachedSortingOrder = m_Renderer.sortingOrder;
		//Debug.Log(MyRenderer.sortingLayerName + " " + MyRenderer.sortingOrder);
	}

	void GetRenderer()
    {
		if (!m_Renderer)
		{
			m_Renderer = GetComponent<Renderer>();
		}
	}
}
