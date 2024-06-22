using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PersonalLibrary.Utilities;
using FlappyDaBurd.Datagram;

namespace Core
{
    public class DataManager : Singleton<DataManager>
    {
        [SerializeField] private int hp = Constant.Num.DefaultHealth;

        public int HealthPoints => hp;

        public int DecreaseHP(int damage = 1)
        {
            return hp -= damage;
        }
    }
}