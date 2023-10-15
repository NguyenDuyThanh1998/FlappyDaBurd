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

        public override void Spawn(GameObject _obj)
        {
            var pipe = LeanPool.Spawn(_obj);
            pipe.transform.SetParent(parent);
        }
    }
}
