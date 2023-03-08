using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public class Obstacle : Spawnable
    {
        /*[SerializeField]
        SoundID m_CollideSound = SoundID.None;*/
        const string k_FlappyTag = "Flappy";
        Renderer[] m_Renderers;

        protected override void Awake()
        {
            base.Awake();

            m_Renderers = gameObject.GetComponents<Renderer>();
        }

        public override void ResetSpawnable()
        {
            for (int i = 0; i < m_Renderers.Length; i++)
            {
                m_Renderers[i].enabled = true;
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_FlappyTag))
            {
                //AudioManager.Instance.PlayEffect(m_CollideSound);
                GameManager.Instance.GameOver();
            }
        }
    }
}
