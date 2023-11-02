using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton instance

    private Dictionary<string, int> inventory; // Dictionary to store item counts

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the inventory
        inventory = new Dictionary<string, int>();
        inventory.Add("logs", 0);
        inventory.Add("meat", 0);
        inventory.Add("fruit", 0);
    }

    // Add an item to the inventory
    public void AddToInventory(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            Debug.LogWarning("Item '" + itemName + "' is not recognized and cannot be added to the inventory.");
        }
    }

    // Remove an item from the inventory
    public void RemoveFromInventory(string itemName)
    {
        if (inventory.ContainsKey(itemName) && inventory[itemName] > 0)
        {
            inventory[itemName]--;
        }
        else
        {
            Debug.LogWarning("Item '" + itemName + "' is not in the inventory to remove.");
        }
    }

    // Check if an item is in the inventory
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName) && inventory[itemName] > 0;
    }

    // Get the count of an item in the inventory
    public int GetItemCount(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName];
        }
        return 0;
    }
}