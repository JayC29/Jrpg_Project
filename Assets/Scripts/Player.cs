using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    public static Player Instance { set; get; }
    [SerializeField]
    public Stat health;

    [SerializeField]
    private Stat mana;

    private float initMana = 50;

    private float initHealth = 1000;

    private SpellBook spellBook;

    public Transform target { get; set; }

    // Use this for initialization
    protected override void Start()
    {
        Instance = this;
        spellBook = GetComponent<SpellBook>();
        Debug.Log("I'm Woke");
        health.Initialize(initHealth, initHealth);

        mana.Initialize(initMana, initMana);
        StartCoroutine(ManaRecharge());
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();
        // InLineOfSight();
        base.Update();
    }

    private void GetInput()
    {

        direction = Vector2.zero;

        ///THIS IS USED FOR DEBUGGING ONLY (health go down, and health go up)
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }



        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !IsMoving)
            {
                //TODO CHANGE INDEX IF MORE SPELLS ADDED
                attackRoutine = StartCoroutine(Attack(0));
            }

        }
    }
    public IEnumerator ManaRecharge()
    {
        while(true)
        {
            mana.MyCurrentValue += 1f;
            yield return new WaitForSeconds(1); //cast time
        }
        

    }

    public IEnumerator Attack(int spellIndex)
    {
        Spell spell = spellBook.CastSpell(spellIndex);
        isAttacking = true;
        animator.SetBool("attack", isAttacking);

        yield return new WaitForSeconds(spell.CastTime); //cast time
        Debug.Log("reached cast spell");
        CastSpell(spell);

        StopAttack();
    }

    public void CastSpell(Spell spell)
    {
        if(mana.MyCurrentValue > 4)
        {
            Instantiate(spell.SpellPrefab, transform.position, Quaternion.identity);
            mana.MyCurrentValue -= 5;
        }

    }

    private bool InLineOfSight()
    {
        Debug.Log("transform is " + target.transform.position);
        Vector3 targetDirection = (target.transform.position - transform.position).normalized;

        Debug.DrawRay(transform.position, targetDirection);
        return false;
    }

    public override void StopAttack()
    {
        spellBook.StopCast();
        base.StopAttack();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //     Transform transform = collision.gameObject.transform.Find("Hitbox");
    //    GameObject ChildGameObject1 = null;
    //    if (transform == null)
    //    {
    //        Debug.Log("transform is null");
    //    }
    //    else
    //    {
    //        ChildGameObject1 = transform.gameObject;
    //        Debug.Log("gameobject is null");
    //    }

        
    //    if (ChildGameObject1 != null)
    //    {
    //        //collision.IsTouching(ChildGameObject1.GetComponent<Collider2D>())
    //        Debug.Log("entered rats collider" + " my tag is: " + ChildGameObject1.tag + "name is : " + ChildGameObject1.name);
    //        health.MyCurrentValue -= 1;
    //    }
    //}
}
