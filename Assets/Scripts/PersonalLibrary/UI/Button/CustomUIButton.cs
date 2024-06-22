using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

using PersonalLibrary.Utilities;

namespace PersonalLibrary.pUnity.pUI
{
    [DisallowMultipleComponent] [RequireComponent(typeof(Image))] [System.Serializable]
    public abstract class CustomUIButton : MonoBehaviour, IMoveHandler, ISubmitHandler, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        //protected Transform parent;
        protected Vector3 ogPosition;
        protected Vector3 ogEulAngles;
        protected Vector3 ogLocalScale;
        protected Image firstRenderImage;

        [SerializeField] private bool isInteractable = true;
        [SerializeField] private bool isHighlighted  = false;
        [SerializeField] private bool isPressed      = false;
        [SerializeField] private bool isHidden       = false;
        [SerializeField] private bool isDoomed       = false;

        //[SerializeField] protected bool isSfx      = true;
        //[SerializeField] protected bool isVfx      = true;
        //[SerializeField] protected bool isTween    = true;
        //[SerializeField] protected bool isPartical = false;

        private UnityEvent onClick = new UnityEvent();

        #region Public Accessor
        public bool IsActive
        {
            get => isActiveAndEnabled;
            set
            {
                enabled = value;
                gameObject.SetActive(value);
            }
        }

        public bool IsInteractable
        {
            get => isInteractable;
            set => isInteractable = value;
        }

        public bool IsHighlighted
        {
            get => isHighlighted;
            //set => isHighlighted = value;
        }

        public bool IsPressed
        {
            get => isPressed;
            //set => isPressed = value;
        }

        public bool IsHidden
        {
            get => isHidden;
            set => isHidden = value;
        }

        public bool IsDestroyed
        {
            get => isDoomed;
            set => isDoomed = value;
        }

        public UnityEvent ClickEvent
        {
            get => onClick;
            set => onClick = value;
        }

        #endregion

        #region Methods
        protected virtual void Awake()
        {
            ogPosition   = transform.localPosition;
            ogEulAngles  = transform.localEulerAngles;
            ogLocalScale = transform.localScale;
            firstRenderImage = GetComponent<Image>();
        }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }

        protected bool Pressed()
        {
            return isPressed = true;
        }

        protected bool Released()
        {
            return isPressed = !isPressed;
        }

        protected void Vanish()
        {
            isHidden = true;
            gameObject.SetActive(!isHidden);
        }

        protected bool Deactivate()
        {
            return isInteractable = false;
        }

        protected void SelfDestruct()
        {
            isDoomed = true;
            Destroy(gameObject, .2f);
        }

        protected void Clicked()
        {
            if (isActiveAndEnabled && isInteractable)
            {
                //UISystemProfilerApi.AddMarker("Button.onClick", this);
                onClick.Invoke();
            }
            else return;
        }
        #endregion

        #region Pointer actions
        public virtual void OnSelect(BaseEventData eventData) { }
        public virtual void OnDeselect(BaseEventData eventData) { }
        
        public virtual void OnPointerEnter(PointerEventData eventData) { }
        public virtual void OnPointerExit(PointerEventData eventData) { }
        
        public virtual void OnPointerUp(PointerEventData eventData) { }
        public virtual void OnPointerDown(PointerEventData eventData) { }

        public virtual void OnPointerClick(PointerEventData eventData) { }
        public virtual void OnSubmit(BaseEventData eventData) { }
        public virtual void OnMove(AxisEventData eventData) { }

        #endregion
    }
}
