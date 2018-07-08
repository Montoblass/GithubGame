using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{

    public Coroutine comboCheck;
    public float comboWait;
    public KeyCode attackKey;
    public KeyCode Stance;
    public Collider2D attackTrigger;

    private PlayerActions actions;
    private Animator anim;

    public enum PlayerActions
    {


        Idle = 0,
        Attack = 1,
        Jump = 2,
        Defend = 4,
        SpecialAttack = 8,
        Die = 16

    }

    public class Player : MonoBehaviour
    {
        public Coroutine comboCheck;
        public float comboWait;
        public KeyCode attackKey;
        public Collider2D attackTrigger;

        private PlayerActions actions;
        private Animator anim;
        private KeyCode Stance;

        void Awake()
        {
            anim = GetComponent<Animator>();
            attackTrigger.enabled = false;
        }

        public void CreateHitbox(int createhitbox)
        {
            attackTrigger.enabled = true;
        }


        public void DestroyHitbox(int destroyhitbox)
        {
            attackTrigger.enabled = false;
        }


        void Update()
        {
            TrackActions();
            UpdateAnimator();
            

                if (Input.GetKeyDown(Stance))
                    anim.SetTrigger("Stance");

              

            
        }

        void UpdateAnimator()
        {
            anim.SetBool("attack1", (actions & PlayerActions.Attack) == PlayerActions.Attack);
            anim.SetBool("Defend", (actions & PlayerActions.Defend) == PlayerActions.Defend);
            anim.SetBool("SpecialAttack", (actions & PlayerActions.SpecialAttack) == PlayerActions.SpecialAttack);
            anim.SetBool("Die", (actions & PlayerActions.Die) == PlayerActions.Die);
        }

        void TrackActions()
        {

            if (Input.GetKeyDown(Stance))
            {

                if (Input.GetKey(attackKey)) actions |= PlayerActions.Attack;
                else if ((actions & PlayerActions.Attack) == PlayerActions.Attack && comboCheck == null) actions ^= PlayerActions.Attack;

                if (comboCheck == null) comboCheck = StartCoroutine(ComboCheck());

            }


        }


        IEnumerator ComboCheck()
        {
            WaitForSeconds wait = new WaitForSeconds(comboWait);
            yield return wait;

            // Your combo criteria:
            if ((actions & PlayerActions.Jump) == PlayerActions.Jump && (actions & PlayerActions.Attack) == PlayerActions.Attack)
            {
                // Do some cool Jump + Attack wombo combo...
            }
        }
    }
}
