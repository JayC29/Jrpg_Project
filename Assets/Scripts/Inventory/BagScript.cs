using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;

    //  A canvasgroup for hiding and showing the bag
    private CanvasGroup canvasGroup;

    private List<SlotScript> slots = new List<SlotScript>();

    // Indicates if the bag is open
    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha > 0;
        }
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void AddSlots(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
           SlotScript slot = Instantiate(slotPrefab, transform).GetComponent<SlotScript>();
            slots.Add(slot); 
        }
    }

    public bool AddItem(Item item)
    {
        foreach (SlotScript slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.AddItem(item);

                return true;
            }
        }

        return false;
    }

    public void OpenClose()
    {
        Debug.Log("Oof");
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
}
