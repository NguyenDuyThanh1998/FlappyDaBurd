using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PersonalLibrary.Utilities;

using FlappyDaBurd.Datagram;

namespace FlappyDaBurd
{
    public class Spawner_Score_pipe : Spawner
    {
        [SerializeField] private Score score;

        protected override void LoadSpawnable()
        {
            if(!score)
                score = GetComponentFromPrefab(Constant.Str.PrefabFolder + Constant.Str.ScorePipePrefab) as Score;
        }

        private void OnEnable()
        {
            EventManager.AddListener<EventPipeSpawn>(Spawn);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<EventPipeSpawn>(Spawn);
        }

        private void Spawn(EventPipeSpawn _pipe)
        {
            score.Asset = _pipe.asset;
            score.DoSpawn(parent);
        }
    }
}
