using UnityEngine;

using static FlappyDaBurd.Datagram.Constant;

[CreateAssetMenu(menuName = "Scriptable Objects/HitPoints", fileName = PATH.FOLDER_RESOURCES + PATH.SO_HIT_POINTS + "HP_", order = 30)]
public class SO_HitPoints : ScriptableObject, IDamageable<int>, IHealable<int>
{
    [SerializeField] private bool persist = false;
    [SerializeField] private int maxValue = INT32.DEFAULT_HEALTH;
    [SerializeField] private int currrentValue;

    private void OnEnable()
    {
        if (!persist)
        {
            currrentValue = maxValue;
        }
    }

    public int Value { get => currrentValue; }

    public int TakeHit(int hp = 1)
    {
        return currrentValue -= hp;
    }

    public int Heal(int hp = 1)
    {
        return currrentValue += hp;
    }
}