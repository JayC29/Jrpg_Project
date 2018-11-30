using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {

    public static SceneSelector Instance {set; get;}
    [SerializeField]
    private string loadLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("upadated");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Collider, trying to load scene: " + loadLevel + " tag is: " + other.tag + " my tag is " + this.tag);
        if (this.tag =="Dungeon Entrance" && other.tag == "Player")
        {
            SceneManager.LoadScene(loadLevel);
        }
        else if(this.tag == "Dungeon Exit" && other.tag == "Player")
        {
            SceneManager.LoadScene(loadLevel);

        }
    }
}
