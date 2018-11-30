using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    private static InventoryScript instance;

    public static InventoryScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }

            return instance;
        }
    }

    private List<Bag> bags = new List<Bag>();

    [SerializeField]
    private BagButton[] bagButtons;

    //for debugging
    [SerializeField]
    private Item[] items;

    public bool CanAddBag
    {
        get { return bags.Count < 1; }
    }

    private void Awake()
    {
        Bag MyBag = (Bag)Instantiate(items[0]);
        MyBag.Initialize(15);
        MyBag.Use();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Bag MyBag = (Bag)Instantiate(items[0]);
            MyBag.Initialize(15);
            MyBag.Use();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryScript.MyInstance.OpenClose();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Bag MyBag = (Bag)Instantiate(items[0]);
            MyBag.Initialize(15);
            AddItem(MyBag);
        }
    }

    public void AddBag(Bag bag)
    {
        foreach (BagButton bagButtons in bagButtons)
        {
            if (bagButtons.MyBag == null)
            {
                bagButtons.MyBag = bag;
                bags.Add(bag); 
                break;
            }
        }
    }

    public void AddItem(Item item)
    {
        foreach (Bag bag in bags)
        {
            if (bag.MyBagScript.AddItem(item))
            {
                return;
            }
        }
    }

    public void OpenClose()
    {
        bool closedBag = bags.Find(x => !x.MyBagScript.IsOpen);

        // if closedBag = true, then open all closed bags
        // if closedBag = false, then close all open bags

        foreach (Bag bag in bags)
        {
            if (bag.MyBagScript.IsOpen != closedBag)
            {
                bag.MyBagScript.OpenClose();
            }
        }
    }

}
