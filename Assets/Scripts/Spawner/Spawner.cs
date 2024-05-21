using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected Spawnable spawnableObj;
        [SerializeField] protected Transform parent;

        public abstract void Spawn(Spawnable _spawnable);
    }
}
