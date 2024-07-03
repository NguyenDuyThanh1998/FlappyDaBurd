using UnityEngine;

using static FlappyDaBurd.Datagram.Constant;

public class Background : Parallax
{
    [SerializeField] protected SO_ParallaxIndex background;

    protected override void OnEnable()
    {
        background = Resources.Load<SO_ParallaxIndex>(PATH.SO_BACKGROUND + "Parallax_Background_00");
    }

    protected override void FixedUpdate()
    {
        Movement(background.Speed);
    }

    //protected override void Movement(float _parallaxIndex)
    //{
    //    m_MeshRenderer.material.mainTextureOffset += _parallaxIndex * Time.fixedDeltaTime * Vector2.right;
    //}
}
