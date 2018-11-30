using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D rigidbody;

    [SerializeField]
    private float spellSpeed;

    private Transform target;

    // Use this for initialization
    void Start() {
        spellSpeed = 3;
        rigidbody = GetComponent<Rigidbody2D>();

        GameObject tempObj = FindClosestToTarget(this.transform, "Enemy");

        if (tempObj != null)
        {
            Debug.Log("not null");
        }
        else
        {
            Debug.Log("it was null");
            Destroy(gameObject);
        }


        target = tempObj.transform;

        
        //Debug.Log("Target is " + );
    }

    //find closest enemy at spellcast
    GameObject FindClosestToTarget(Transform spellLocation, string tag)
    {
        GameObject[] options = GameObject.FindGameObjectsWithTag(tag);

        Debug.Log("find closest checkpoint 1" + " checking options count: " + options.Length);
        if (options.Length == 0)
            return null;
        Debug.Log("find closest checkpoint 2");
        GameObject closest = options[0];
        float closestDistance = Vector2.Distance(spellLocation.position, closest.transform.position);
        float thisDistance;

        for (int i = 1; i < options.Length; i++)
        {
            thisDistance = Vector3.Distance(spellLocation.position, options[i].transform.position);
            if (thisDistance < closestDistance)
            {
                closest = options[i];
                closestDistance = thisDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 direction = target.position - transform.position;

            rigidbody.velocity = direction.normalized * spellSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GetComponent<Animator>().SetTrigger("impact");
            rigidbody.velocity = Vector2.zero;
            target = null;
        }
    }

}
