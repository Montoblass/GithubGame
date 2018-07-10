using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    // You can use array of sting instead of enum (It's not the most scalable solution to use enum but it's faster (maybe it's a micro optimization in this case))
    public enum AttackComboTypes { UpwardsSlash, DownwardsSlash }
    private AttackComboTypes _nextComboAttack;

    public KeyCode Stance1;

    public KeyCode Attack1;

    private bool attack1 = false;

    private float attackTimer = 0;

    private Dictionary<int, int> _animationHashCodesContainer;

    // or

    [SerializeField] private string[] _attackComboAnimationNames;
    private int _nextComboAttackIndex;

    private Dictionary<string, int> _animationNamesHashCodesContainer;

    private Animator _animator;

    protected virtual void Awake()
    {
        this._animator = this.GetComponent<Animator>();

        this._animationHashCodesContainer.Add((int)AttackComboTypes.UpwardsSlash, Animator.StringToHash(AttackComboTypes.UpwardsSlash.ToString()));
        this._animationHashCodesContainer.Add((int)AttackComboTypes.DownwardsSlash, Animator.StringToHash(AttackComboTypes.DownwardsSlash.ToString()));
        // or

        for (int i = 0; i < this._attackComboAnimationNames.Length; i++)
        {
            // Don't actually know if this helps to gain more performance in case you need to get hash code from string anyway
            // It's probably useless to use dictionary in this case
            // So I will continue just passing the name of the animation to trigger
            this._animationNamesHashCodesContainer.Add(this._attackComboAnimationNames[i], Animator.StringToHash(this._attackComboAnimationNames[i]));
        }

        this.StartCoroutine(this.CheckForCombo());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this._attackFlag = true;           
            this.Attack();
            
        }
    }
  
    // or

    private bool _attackFlag;
    private bool _comboFlag;
    public void Attack()
    {
        // This is just to ensure that you don't attack till check for combo is completed (it's some kind of cooldown)
        if (this._comboFlag)
        {

            if (Input.GetKeyDown(Stance1))
                _animator.SetTrigger("Stance");

            if (Input.GetKeyUp(Stance1))
                _animator.SetTrigger("Stance");

            if (Input.GetKey(Stance1))
            {




                //Melee attack
                if (Input.GetKeyDown(Attack1) && !attack1)
                {

                    attack1 = true;               

                }


                if (attack1)
                {
                    if (attackTimer > 0)
                    {

                        attackTimer -= Time.deltaTime;
                    }
                    else
                    {
                        attack1 = false;

                    }
                }

                _animator.SetBool("attack1", attack1);
                // Some attacking code
                // ......
                // end

                this.PlayNextCombo();

            this._comboFlag = false;
        }
    }

    private IEnumerator CheckForCombo()
    {
        while (true)
        {
            // Simple, we wait for some time, if player pressed attack then we don't reset combo 
            // If he has been IDLE, we reset it
            yield return new WaitForSecondsRealtime(this._attackComboTimeDifference);

            if (!this._attackFlag)
                this.ResetCombo();

            this._attackFlag = false;


            this._comboFlag = true;
        }
    }

    private void PlayNextCombo()
    {
        this._animator.SetTrigger(this._attackComboAnimationNames[this._nextComboAttackIndex]);

        this._nextComboAttackIndex = (this._nextComboAttackIndex + 1) % this._attackComboAnimationNames.Length;
    }

    private void ResetCombo()
    {
        this._nextComboAttackIndex = 0;
    }
}