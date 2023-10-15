using FlappyDaBurd;
using UnityEngine;

public class Background : Parallax
{
    [SerializeField] protected SO_ParallaxIndex background;

    protected override void OnEnable()
    {
        background = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Background_00");
    }

    protected override void FixedUpdate()
    {
        Movement(background.speed);
    }
}
