using System.Collections;
using UnityEngine;

using PersonalLibrary.Utilities;

using FlappyDaBurd.Datagram;

namespace FlappyDaBurd
{
    public class Spawner_Pipe : Spawner
    {
        [SerializeField] private Pipes pipe;
        [SerializeField] private SO_Pipe asset;
        [SerializeField] private SO_Pipe assetInstance;

        protected override void LoadSpawnable()
        {
            if (!pipe)
                pipe = GetComponentFromPrefab(Constant.Str.PrefabFolder + Constant.Str.PipePrefab) as Pipes;
        }

        protected override void LoadAsset()
        {
            if (!asset)
                asset = Resources.Load<SO_Pipe>(Constant.Str.SO_Pipes + "Pipes_00");
        }

        public override void Initialize()
        {
            // pass SO asset into spawnables before they get pooled
            //assetInstance = ScriptableObject.CreateInstance<asset>();
            pipe.Asset = asset;
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
                pipe.DoSpawn(parent);
                EventManager.Raise(new EventPipeSpawn() { obj = pipe, asset = asset });
            }
        }

        //void Spawn(Pipes _pipe, SO_Pipe _resource)
        //{
        //    _pipe.Resource = _resource;
        //    _pipe.DoSpawn(parent);
        //    EventManager.Raise(new EventPipeSpawn() { obj = _pipe, resource = _resource });
        //}
    }
}
