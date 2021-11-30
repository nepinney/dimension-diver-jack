using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackpackSlot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // Event to know when the user wants to use the item during gameplay
    public delegate void ActivateItemEvent(string itemName);
    public event ActivateItemEvent OnActivateItem;

    // Event to know when the user wants to move an item from the inventory to the backpack
    public delegate void MoveToBackpackEvent(int slotNumber);
    public event MoveToBackpackEvent OnMoveToBackpack;

    // The slot number in the 
    public int slotNumber;
    public bool isSlotActive = false;
    public bool readyForSwap = false;
    private GameObject activeClone;
    private Image background;
    //private Button button;

    private void OnEnable()
    {
        name = gameObject.name;
        background = GetComponent<Image>();
    }

    public void Initialize()
    {
        PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        slotNumber = int.Parse(name.Substring(name.Length - 1));
        if (prefManager.GetBackpackSlotStatus(slotNumber) != "Empty")
        {
            isSlotActive = true;
            GameObject slotObject = prefManager.inventoryObjects[prefManager.GetBackpackSlotStatus(slotNumber)];
            activeClone = Instantiate(slotObject, GetComponent<RectTransform>());
        }
    }

    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData data)
    {
        // if greater than 1 than it has a image in the slot meaning a object is selected for use
        if (SceneManager.GetActiveScene().name != "Homebase")
        {
            if (isSlotActive)
            {
                background.color = new Color32(21, 0, 255, 255);
                OnActivateItem?.Invoke(GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>().GetBackpackSlotStatus(slotNumber));
            }
        }
        else
        {
            if (readyForSwap)
            {
                OnMoveToBackpack?.Invoke(slotNumber);
            }
        }
    }

    public void AddItemToSlot(string objectName)
    {
        PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        prefManager.SetBackpackSlotStatus(slotNumber, objectName);
        isSlotActive = true;
        GameObject slotObject = prefManager.inventoryObjects[objectName];
        activeClone = Instantiate(slotObject, GetComponent<RectTransform>());
    }

    public void ReplaceItem(string newObjectName)
    {
        PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        Destroy(activeClone);
        prefManager.SetBackpackSlotStatus(slotNumber, newObjectName);
        GameObject slotObject = prefManager.inventoryObjects[newObjectName];
        activeClone = Instantiate(slotObject, GetComponent<RectTransform>());
        activeClone.SetActive(true);
        RemoveHighlight();
        readyForSwap = false;

        //Hide previous item button

    }

    public void HighlightGreen()
    {
        background.color = new Color32(0, 209, 53, 255);
        readyForSwap = true;
    }

    public void RemoveHighlight()
    {
        background.color = new Color(96f / 255f, 96f / 255f, 96f / 255f);
    }
}
