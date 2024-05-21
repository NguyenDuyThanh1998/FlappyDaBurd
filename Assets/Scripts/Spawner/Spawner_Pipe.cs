using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace FlappyDaBurd
{
    public class Spawner_Pipe : Spawner
    {
        private void Start()
        {
            StartCoroutine(Spawning());
        }

        public IEnumerator Spawning()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                Spawn(spawnableObj);
            }
        }

        public override void Spawn(Spawnable _obj)
        {
            LeanPool.Spawn(_obj, parent);
            //pipe.transform.SetParent(parent);
        }
    }
}
