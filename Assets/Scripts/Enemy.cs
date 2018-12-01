using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{

    [SerializeField]
    private Stat health;

    //[SerializeField]
    //private Stat mana;

    //private float initMana = 50;

    private float initHealth;


    //[SerializeField]
    //private CanvasGroup healthGroup;

    private Transform target;

    

    // Use this for initialization
    protected override void Start()
    {
            if (this.name == "Jerry")
            {
                initHealth = 10;
            }
            if (this.name == "Winged_Jerry")
            {
                initHealth = 20;
            }

        Debug.Log("Jerry Woke");
        health.Initialize(initHealth, initHealth);

        base.Start();
    }

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    protected override void Update()
    {
        FollowTarget();

        base.Update();
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
        if (collision.IsTouching(ChildGameObject1.GetComponent<Collider2D>()) && collision.tag == "Player")
        {

            Debug.Log("entered rats collider" + " my tag is: " + ChildGameObject1.tag + "colliderParameter name is: " +collision.name);
            Player.Instance.health.MyCurrentValue -= 1f;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
        if (collision.IsTouching(ChildGameObject1.GetComponent<Collider2D>()) && collision.tag == "Spell")
        {

            Debug.Log("entered rats collider" + " my tag is: " + ChildGameObject1.tag + "colliderParameter name is: " + collision.name);
            health.MyCurrentValue -= 10;

            if (health.MyCurrentValue == 0)
            {
                Destroy(gameObject);
                Debug.Log("JERRY'S DEAD!!");
            }
        }
    }



}
