using UnityEngine;
using PersonalLibrary.Extensions;

namespace PersonalLibrary.Utilities
{
    public class ScreenEdges : MonoBehaviour
    {
        [System.Serializable]
        class Edge
        {
            public GameObject obj;
            public string name;
            public Vector2 dir;

            // Constructor
            public Edge(GameObject _obj, string _name, Vector2 _dir)
            {
                obj = _obj;
                name = _name;
                dir = _dir;
            }
        }

        [SerializeField] float m_Thickness = 2;
        [SerializeField] float m_SizeOffset = 2;
        [SerializeField] Vector2 m_PositionOffset = Vector2.zero;

        [SerializeField] bool Top = false;
        [SerializeField] bool Bottom = false;
        [SerializeField] bool Right = false;
        [SerializeField] bool Left = false;

        Vector2 m_CameraPosition;
        float m_HalfScreenHeight;
        float m_HalfScreenLength;

        private void Awake()
        {
            if (transform.childCount < 1)
            {
                CreateScreenEdges();
            }
        }

        [ContextMenu("Create Edge Colliders")]
        public void CreateScreenEdges()
        {
            DeleteChildren();
            GetScreen();

            if (Top)
            {
                Edge top = new Edge(new(), "Top", Vector2.up);
                SetCollider(SetEdge(top));
            }
            if (Bottom)
            {
                Edge bot = new Edge(new(), "Bottom", Vector2.down);
                SetCollider(SetEdge(bot));
            }
            if (Right)
            {
                Edge right = new Edge(new(), "Right", Vector2.right);
                SetCollider(SetEdge(right));
            }
            if (Left)
            {
                Edge left = new Edge(new(), "Left", Vector2.left);
                SetCollider(SetEdge(left));
            }
        }

        [ContextMenu("Clear All")]
        public void DeleteChildren()
        {
            transform.DestroyImmedeateAllChild();
        }

        public Vector2 GetScreen()
        {
            var cam = Camera.main;
            m_CameraPosition = cam.transform.position;

            if (cam.orthographic)
            {
                m_HalfScreenHeight = cam.orthographicSize;
                m_HalfScreenLength = m_HalfScreenHeight * cam.aspect;
            }
            else
            {
                //////////////////////// WORK IN PROGRESS ////////////////////////

                //var perspectiveCam = cam.ScreenToWorldPoint(m_CameraPosition);
                //var perspectiveWidth = cam.ScreenToWorldPoint(new Vector2(Screen.width, perspectiveCam.y));
                //var perspectiveHeight = cam.ScreenToWorldPoint(new Vector2(perspectiveCam.x, Screen.height));

                var perspectiveBase = cam.ScreenToWorldPoint(Vector2.zero);
                var perspectiveWidth = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0));
                var perspectiveHeight = cam.ScreenToWorldPoint(new Vector2(0, Screen.height));

                m_HalfScreenLength = Vector2.Distance(perspectiveBase, perspectiveWidth) / 2;
                m_HalfScreenHeight = Vector2.Distance(perspectiveBase, perspectiveHeight) / 2;
            }

            //Debug.Log("height: " + m_HalfScreenHeight);
            //Debug.Log("length: " + m_HalfScreenLength);
            return new Vector2(m_HalfScreenLength, m_HalfScreenHeight);
        }

        Edge SetEdge(Edge _edge)
        {
            var _object = _edge.obj;
            _object.SetParent(transform);           // Set parent for GO.
            _object.SetName(_edge.name);            // Name the GO.
            _object.AddComponent<BoxCollider2D>();  // Add BoxCollider component.
            return _edge;
        }

        BoxCollider2D SetCollider(Edge _edge)
        {
            if (_edge.obj.TryGetComponent(out BoxCollider2D _col))
            {
                Vector2 _posOffset = m_PositionOffset;
                Vector2 _halfScreenSize = GetScreen();
                Vector2 _colSize = ColliderSize(_halfScreenSize);

                if (_edge.dir == Vector2.right || _edge.dir == Vector2.left)
                {
                    _posOffset = m_PositionOffset.Swap();
                    _halfScreenSize = GetScreen().Swap();
                    _colSize = ColliderSize(_halfScreenSize).Swap();
                }

                _col.size = _colSize;
                _col.transform.position = m_CameraPosition + _edge.dir * _halfScreenSize.y;
                _col.offset = _edge.dir * (m_Thickness / 2 + _posOffset.y);
                return _col;
            }
            else
            {
            #if UNITY_EDITOR
                Debug.LogError(_edge.name + " edge doesn't have BoxCollider2D");
            #endif
                return null;
            }
        }

        Vector2 ColliderSize(Vector2 _halfScreenSize)
        {
            return new Vector2((_halfScreenSize.x + m_SizeOffset) * 2, m_Thickness);
        }

        // <summary> Old stuff. Keep for reference only
        //void SetTopCollider(Edge _edge)
        //{
        //    if (_edge.obj.TryGetComponent(out BoxCollider2D _col))
        //    {
        //        _col.size = new Vector2((GetScreen().x + m_SizeOffset) * 2, m_Thickness);
        //        _col.transform.position = m_CameraPosition + Vector2.up * GetScreen().y;
        //        _col.offset = Vector2.up * (m_Thickness / 2 + m_PositionOffset.y);
        //    }
        //    else
        //        Debug.LogError("TopEdge doesn't have BoxCollider2D");
        //}

        //void SetBottomCollider(Edge _edge)
        //{
        //    if (_edge.obj.TryGetComponent(out BoxCollider2D _col))
        //    {
        //        _col.size = new Vector2((GetScreen().x + m_SizeOffset) * 2, m_Thickness);
        //        _col.transform.position = m_CameraPosition + Vector2.down * GetScreen().y;
        //        _col.offset = Vector2.down * (m_Thickness / 2 + m_PositionOffset.y);
        //    }
        //    else
        //        Debug.LogError("BottomEdge doesn't have BoxCollider2D");
        //}

        //void SetRightCollider(Edge _edge)
        //{
        //    if (_edge.obj.TryGetComponent(out BoxCollider2D _col))
        //    {
        //        _col.size = new Vector2(m_Thickness, (GetScreen().y + m_SizeOffset) * 2);
        //        _col.transform.position = m_CameraPosition + Vector2.right * GetScreen().x;
        //        _col.offset = Vector2.right * (m_Thickness / 2 + m_PositionOffset.x);
        //    }
        //    else
        //        Debug.LogError("RightEdge doesn't have BoxCollider2D");
        //}

        //void SetLeftCollider(Edge _edge)
        //{
        //    if (_edge.obj.TryGetComponent(out BoxCollider2D _col))
        //    {
        //        _col.size = new Vector2(m_Thickness, (GetScreen().y + m_SizeOffset) * 2);
        //        _col.transform.position = m_CameraPosition + Vector2.left * GetScreen().x;
        //        _col.offset = Vector2.left * (m_Thickness / 2 + m_PositionOffset.x);
        //    }
        //    else
        //        Debug.LogError("LeftEdge doesn't have BoxCollider2D");
        //}
        // </summary>
    }
}
