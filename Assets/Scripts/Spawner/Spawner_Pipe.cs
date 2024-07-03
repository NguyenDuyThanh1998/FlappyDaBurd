using System.Collections;
using UnityEngine;

using Lean.Pool;
using PersonalLibrary.Utilities;
using PersonalLibrary.pUnity.pAttribute;

using static FlappyDaBurd.Datagram.Constant;

namespace FlappyDaBurd
{
    public class Spawner_Pipe : Spawner
    {
        [SerializeField] private Pipes spawnable;

        [Header("Asset")]
        [SerializeField, ReadOnly] private SO_Pipe assetReference;

        protected override void GetResources()
        {
            if (!spawnable)
                spawnable = GetSpawnableFromPrefab<Pipes>(PATH.PREFAB_PIPE);
            if (!assetReference)
                assetReference = GetAssetReference<SO_Pipe>(PATH.SO_PIPES + "Pipes_00");
        }

        private void Start()
        {
            StartCoroutine(Spawning());
        }

        public IEnumerator Spawning()
        {
            while (isSpawn)
            {
                yield return new WaitForSeconds(3);

                var assetInstance = assetReference.Copy<SO_Pipe>();
                spawnable.Initialize(assetInstance);
                LeanPool.Spawn(spawnable, parent);

                EventManager.Raise(new EventPipeSpawn(assetInstance));
            }
        }
    }
}
