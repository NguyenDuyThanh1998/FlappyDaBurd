using UnityEngine;

public abstract class SO_Obstacle : SO_Spawnable
{
    [SerializeField] int damage;

    public int Damage => damage;
}
