using UnityEngine;

public class Ground : Parallax
{
    [SerializeField] protected SO_ParallaxIndex ground;

    protected override void OnEnable()
    {
        ground = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Ground_00");
    }

    protected override void FixedUpdate()
    {
        Movement(ground.speed);
    }
}
