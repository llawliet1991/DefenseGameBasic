using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDefense.Basic
{
    public class Enemy : MonoBehaviour, IComponentChecking
    {
        public float speed;
        public float atkDistance;
        private Animator m_anim;
        private Rigidbody2D m_rb;
        private Player m_player;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();           
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public bool IsComponentsNull()
        {
            return m_anim == null||m_rb==null||m_player==null;
        }
        // Update is called once per frame
        void Update()
        {
            if (IsComponentsNull()) return;
            float disToPlayer = Vector2.Distance(m_player.transform.position, transform.position);
            if (disToPlayer <= atkDistance)
            {              
                m_anim.SetBool(Const.ATTACK_ANIM,true);              
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }
        public void Die()
        {
            if (IsComponentsNull()) return;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_PLAYER);
        }

    }
}
