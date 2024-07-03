using UnityEngine;

using FlappyDaBurd.Datagram;

public class Ground : Parallax
{
    [SerializeField] protected SO_ParallaxIndex ground;

    protected override void OnEnable()
    {
        ground = Resources.Load<SO_ParallaxIndex>(Constant.PATH.SO_GROUND + "Parallax_Ground_00");
    }

    protected override void FixedUpdate()
    {
        Movement(ground.Speed);
    }

    protected override void Movement(float _parallaxIndex)
    {
        m_MeshRenderer.material.mainTextureOffset += _parallaxIndex * Time.fixedDeltaTime / RATIO * Vector2.right;
    }
}
