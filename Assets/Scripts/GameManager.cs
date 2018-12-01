using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField]
    public GameObject prefab;

    [SerializeField]
    private GameObject player;


    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            if (Player.Instance.health.MyCurrentValue == 0)
            {
                Destroy(player.gameObject);
                StartCoroutine(PlayerRespawn());
            }
        }


	}

    public IEnumerator PlayerRespawn()
    {
        
         yield return new WaitForSeconds(5); //cast time
        //GameObject ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
        player = Instantiate(prefab, GameObject.Find("Spawn Point").transform);
        player.transform.position = GameObject.Find("Spawn Point").transform.position;


    }


}
