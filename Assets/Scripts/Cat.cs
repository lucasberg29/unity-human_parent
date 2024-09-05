using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private bool isCanInteract;

    private GameObject objectToInteractWith;
    private List<InventoryItem> inventory;

    public GameObject interactDialog;
    public GameObject foodDialog;
    public GameObject moneyDialog;
    public GameObject gainedMoneyDialog;
    public InventoryManager inventoryManager;
    public TextMeshProUGUI moneyText;
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new();
        UpdateMoney();
        CreateInventoryList();
    }

    private void CreateInventoryList()
    {
        inventoryManager.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateMoney()
    {
        moneyText.text = $"$ {money}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collissionObjectTag = collision.gameObject.tag;

        switch (collissionObjectTag)
        {
            case "Human":
                interactDialog.SetActive(true);
                foodDialog.SetActive(true);
                moneyDialog.SetActive(false);
                isCanInteract = true;
                objectToInteractWith = collision.gameObject;
                break;
            case "VendingMachine":
                interactDialog.SetActive(true);
                moneyDialog.SetActive(true);
                isCanInteract = true; 
                objectToInteractWith = collision.gameObject;
                break;
            case "Item":
                collision.gameObject.GetComponent<AudioSource>().Play();

                int childrenNumber = collision.gameObject.transform.childCount;

                for (int i = 0; i < childrenNumber; i++)
                {
                    collision.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
                //children.ToList().ForEach(child => child.gameObject.SetActive(false));

                //Debug.Log("Children: " + children.ToString() + children.Length);

                Destroy(collision.gameObject, 1.0f);
                AddFoodToInventory(1);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactDialog.SetActive(false);
        foodDialog.SetActive(false);
        moneyDialog.SetActive(false);
    }

    private void AddFoodToInventory(int numberOfItems)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            inventory.Add(new(ItemType.Food));
            inventoryManager.AddItemToInventory(new(ItemType.Food));
        }
    }

    public void InteractWithGameObject()
    {
        string objectTag = objectToInteractWith.tag;

        switch (objectTag)
        {
            case "Human":
                Human humanObject = objectToInteractWith.gameObject.GetComponent<Human>();
                humanObject.Meow();

                if (inventory.Count > 0)
                {
                    if (humanObject.FeedHuman())
                    {
                        RemoveLastItemFromInventory();
                    }
                }
                break;
            case "VendingMachine":
                PayMachine(objectToInteractWith.GetComponent<VendingMachine>());
                break;
        }
    }

    private void PayMachine(VendingMachine vendingMachine)
    {
        if (money - vendingMachine.vendingMachinePrice >= 0)
        {
            money -= vendingMachine.vendingMachinePrice;
            vendingMachine.ShowMoneySpent();
            AddFoodToInventory(1);
        }

        UpdateMoney();
    }

    private void RemoveLastItemFromInventory()
    {
        if (inventory.Count > 0) 
        {
            inventory.RemoveAt(inventory.Count - 1);
            inventoryManager.RemoveItemFromInventory();
        }
    }

    public void GainMoney(int dollars)
    {
        money += dollars;
        UpdateMoney();
    }
}
