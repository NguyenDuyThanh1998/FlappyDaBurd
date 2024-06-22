using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ParallaxIndex", fileName = "Parallax_")]
public class SO_ParallaxIndex : ScriptableObject
{
    [SerializeField] float speed;
    public float Speed => speed;

    // Const
    const float MIN_SPEED = 0;
    const float MAX_SPEED = 10;

    public float ForceStop()
    {
        return speed = MIN_SPEED;
    }
    public float HyperJump()
    {
        return speed = MAX_SPEED;
    }
}