using FlappyDaBurd.Core;
using UnityEngine;

public class Background : Parallax
{
    [SerializeField] [ReadOnly] protected SO_ParallaxIndex background;

    protected override void FixedUpdate()
    {
        m_Transform.position = GetPosition(background.speed);
    }

    protected override void OnEnable()
    {
        background = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Background_00");
    }
}
