using System.Collections;
using UnityEngine;

using Lean.Pool;
using PersonalLibrary.Utilities;
using PersonalLibrary.pUnity.pAttribute;

using static FlappyDaBurd.Datagram.Constant;

namespace FlappyDaBurd
{
    public class Spawner_Score_pipe : Spawner
    {
        [SerializeField] private Score spawnable;

        protected override void GetResources()
        {
            if (!spawnable)
                spawnable = GetSpawnableFromPrefab<Score>(PATH.PREFAB_SCORE_PIPE);
        }

        private void OnEnable()
        {
            EventManager.AddListener<EventPipeSpawn>(OnPipeSpawn);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<EventPipeSpawn>(OnPipeSpawn);
        }

        private void OnPipeSpawn(EventPipeSpawn e)
        {
            spawnable.Initialize(e.asset);
            LeanPool.Spawn(spawnable, parent);
        }
    }
}
