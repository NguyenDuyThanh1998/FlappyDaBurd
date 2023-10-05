using FlappyDaBurd.Core;
using UnityEngine;

public class Ground : Parallax
{
    [SerializeField] [ReadOnly] protected SO_ParallaxIndex ground;

    protected override void FixedUpdate()
    {
        m_Transform.position = GetPosition(ground.speed);
    }

    protected override void OnEnable()
    {
        ground = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Ground_00");
    }
}
