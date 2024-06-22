using UnityEngine;

using FlappyDaBurd.Datagram;

public class Background : Parallax
{
    [SerializeField] protected SO_ParallaxIndex background;

    protected override void OnEnable()
    {
        background = Resources.Load<SO_ParallaxIndex>(Constant.Str.SO_Background + "Parallax_Background_00");
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
