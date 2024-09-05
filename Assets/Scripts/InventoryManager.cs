using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventoryItems;
    public GameObject[] inventoryCanvases;
    public Cat cat;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(InventoryItem item)
    {
        inventoryItems.Add(item);
        GameObject canvasToAddItem = GetFirstSpotAvailable();

        if (canvasToAddItem != null ) 
        {
            GameObject imageObject = new();
            imageObject.AddComponent<Image>();

            Image image = imageObject.GetComponent<Image>();
            image.sprite = sprite;
            image.preserveAspect = true;
            image.SetNativeSize();
            image.rectTransform.anchorMin = new Vector2(0, 0);
            image.rectTransform.anchorMax = new Vector2(1, 1);
            image.rectTransform.position = Vector3.zero;

            imageObject.transform.SetParent(canvasToAddItem.transform, false);
            




            Instantiate(imageObject);
        }
    }

    public void RemoveItemFromInventory()
    {
        Debug.Log("gets here");
        inventoryItems.RemoveAt(inventoryItems.Count - 1);

        for (int i = inventoryCanvases.Length - 1; i >= 0; i--) 
        {
            if (inventoryCanvases[i].gameObject.GetComponentInChildren<Image>() is not null)
            {
                Destroy(inventoryCanvases[i].transform.GetChild(0).gameObject);
                break;
            }
        }
    }

    public GameObject GetFirstSpotAvailable()
    {
        foreach (GameObject canvasObject in inventoryCanvases)
        {
            if (canvasObject.gameObject.GetComponentInChildren<Image>() is null)
            {
                return canvasObject;
            }
        }

        return null;
    }

    public void SetInventory(List<InventoryItem> items)
    {
        inventoryItems = items;
    }
}
