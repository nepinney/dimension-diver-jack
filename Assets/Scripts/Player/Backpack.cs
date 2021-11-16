using UnityEngine;
using UnityEngine.SceneManagement;

public class Backpack : MonoBehaviour
{
    public delegate void BackpackSwapEvent();
    public event BackpackSwapEvent OnBackpackSwap;

    private PlayerPrefManager prefManager;

    // Listen for when new items get eqiup after being picked up during level gameplay
    private InteractableObject interactableObject;

    public int countBackpackSlots = 1;
    public BackpackSlot[] backpackSlots;

    //Game objects available to pickup
    public GameObject shovelControls;
    public string possibleNewObject;

    private void OnEnable()
    {
        prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        backpackSlots = new BackpackSlot[countBackpackSlots];
        // Need to know when gameUI has finished loaded to initilize the UI equip slots
        SceneManager.sceneLoaded += GameUILoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= GameUILoaded;
        if (interactableObject) interactableObject.OnObjectPickup -= PutInBackpackSlot;
    }

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
        interactableObject.OnObjectPickup += PutInBackpackSlot;

        //shovel = GameObject.Find("Shovel");
    }

    private void GameUILoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameUI" && mode == LoadSceneMode.Additive)
        {
            for (int i = 0; i < backpackSlots.Length; i++)
            {
                backpackSlots[i] = GameObject.Find("Equip slot " + (i + 1)).GetComponent<BackpackSlot>();
                //break;
                backpackSlots[i].OnMoveToBackpack += MoveSelectedItemToBackpack;
            }

            foreach (BackpackSlot slot in backpackSlots)
            {
                slot.Initialize();
                slot.OnActivateItem += ShowControls;
            }

            shovelControls = GameObject.Find("Shovel Controls");
            shovelControls.SetActive(false);
        }
    }
   

    public void PutInBackpackSlot(string objectName)
    {
        // Remove from map
        GameObject objectOver = GameObject.Find(objectName);
        // Sometimes object over is null im guessing it gets called more than once so wrapped in if so it only executes once
        if (objectOver)
        {
            objectOver.SetActive(false);

            // Put item in inventory
            prefManager.SetObjectStatus(objectName, 1);

            // Update the equip slot to show new object

            // Check backpack slots to see if empty or not
            //int[] backpackSlots = new int[] { 0, 1, 2 };

            bool putInEmptySlot = false;
            foreach (BackpackSlot slot in backpackSlots)
            {
                // Find empty slot to put the image of the new obejct in
                if (!slot.isSlotActive)
                {
                    slot.AddItemToSlot(objectName);
                    putInEmptySlot = true;
                    break;
                }
            }
            if (!putInEmptySlot)
            {
                // Put item in first slot
                backpackSlots[0].ReplaceItem(objectName);
                //backpackSlots[0].AddItemToSlot(objectName);
            }
        }
    }

    public bool isInventoryItemAlreadyInBackpack(string objectName)
    {
        foreach (BackpackSlot slot in backpackSlots)
        {
            if (prefManager.GetBackpackSlotStatus(slot.slotNumber) == objectName) return true;
        }
        return false;
    }


    public void HighlightSlots(string possibleNewObject)
    {
        this.possibleNewObject = possibleNewObject;
        foreach (BackpackSlot slot in backpackSlots)
        {
            slot.HighlightGreen();
        }
    }

    public void GreySlots()
    {
        foreach (BackpackSlot slot in backpackSlots)
        {
            slot.RemoveHighlight();
        }
    }

    private void MoveSelectedItemToBackpack(int slotNumber)
    {
        OnBackpackSwap?.Invoke();
        foreach (BackpackSlot slot in backpackSlots)
        {
            if (slot.slotNumber == slotNumber) slot.ReplaceItem(possibleNewObject);
            break;
        }
    }

    private void ShowControls(string objectName)
    {
        Debug.Log("Trying to show controls");
        switch (objectName)
        {
            case "Shovel":
                shovelControls.SetActive(true);
                break;
            case "Key":
                Debug.Log("No Key controls yet");
                break;
        }
    }
}
