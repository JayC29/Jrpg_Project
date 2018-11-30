using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour {
    [SerializeField]
    private Image castingBar;

    [SerializeField]
    private Text spellName;

    [SerializeField]
    private Spell[] spells;

    [SerializeField]
    private Text castTimeText;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private Coroutine spellRoutine;

    private Coroutine fadeRoutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Spell CastSpell(int index)
    {
        Debug.Log("Bar color 1: " + castingBar.color);
        castingBar.fillAmount = 0;
        spellName.text = spells[index].Name;
        castingBar.color = spells[index].BarColor;
        
        spellRoutine = StartCoroutine(Progress(index));
        Debug.Log("Bar color 2: " + castingBar.color + " SpellName: " + spellName.text);

        fadeRoutine = StartCoroutine(Fadebar());
        return spells[index];
        
    }

    public void StopCast()
    {
        if(fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
            canvasGroup.alpha = 0;
            fadeRoutine = null;
        }
        if(spellRoutine != null)
        {
            StopCoroutine(spellRoutine);
            spellRoutine = null;
        }
    }
    
    private IEnumerator Fadebar()
    {

        float rate = 1.0f / .25f;

        float progress = 0f;

        while (progress <= 1.0)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator Progress(int index)
    {
        float timeLeft = Time.deltaTime;

        float rate = 1.0f / spells[index].CastTime;

        float progress = 0f;

        while(progress <= 1.0)
        {
            castingBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;

            timeLeft += Time.deltaTime;

            castTimeText.text = (spells[index].CastTime - timeLeft).ToString("F2");

            if(spells[index].CastTime -timeLeft < 0)
            {
                castTimeText.text = "0.0";
            }
            yield return null;
        }

        StopCast();
    }
}
