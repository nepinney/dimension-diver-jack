using UnityEngine;

/**
 * This class is designed to fire an events when the player comes into contact with an object that they can interact with (items rack, or pickuppable object)
 * The pickupableObject have colliders on them set to OnTrigger so that the function below gets called during collision between them.
 * Classes subscribed to OnObjectPickup:
 *      Backpack.cs
 * Classes subscribed to OnOverObject & OnNotOverObject:
 *      ItemsUIManager.cs
 */
public class InteractableObject : MonoBehaviour
{

    public delegate void OnOverObjectEvent(string objectName);
    public event OnOverObjectEvent OnOverObject;

    public delegate void OnNotOverObjectEvent(string objectName);
    public event OnNotOverObjectEvent OnNotOverObject;

    public delegate void OnObjectpickupEvent(string objectName);
    public event OnObjectpickupEvent OnObjectPickup;

    private string[] pickupableObjects = new string[] {"Shovel", "Flashlight", "Key", "Axe"};

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Need to check which collision happened or else all isTrigger collisions will fire this event
        if (col.name == "Items rack") OnOverObject?.Invoke(col.name);
        else if (isPickupableObject(col.name))
        {
            OnObjectPickup?.Invoke(col.name);
            //PickupObject(col.name);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Items rack") OnNotOverObject?.Invoke(col.name);
    }

    private bool isPickupableObject(string objectName)
    {
        foreach (string item in pickupableObjects)
        {
            if (item == objectName) return true;
        }
        return false;
    }

}
