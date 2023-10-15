using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected GameObject spawnableObj;
        [SerializeField] protected Transform parent;

        public abstract void Spawn(GameObject _obj);
    }
}
