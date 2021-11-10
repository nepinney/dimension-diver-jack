using UnityEngine;
using UnityEngine.SceneManagement;

//[DefaultExecutionOrder(-3)]
public class ItemsUIManager : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    private InteractableObject interactableObject;

    private GameObject itemUI;
    public RectTransform itemUITransform;
    private Transform itemsRackTransform;

    private Vector3 backpackOriginalPosition;

    public InvSlot[] inventorySlots;
    private string selectedSlot;

    public Backpack backpack;

   
    private void OnEnable()
    {
        inventorySlots = new InvSlot[GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>().inventoryObjects.Count];
        // Need to know when gameUI has finished loaded to get needed components
        SceneManager.sceneLoaded += GameUILoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from all currenlty listening events
        SceneManager.sceneLoaded -= GameUILoaded;
        if (inventorySlots[0].GetType() == typeof(InvSlot))
        {
            foreach (InvSlot slot in inventorySlots)
            {
                slot.OnSlotSelect -= SelectSlot;
            }
        }
    }


    void GameUILoaded(Scene scene, LoadSceneMode mode)
    {
        // Get player object, get interactable, listen for event, display UI
        if (scene.name == "GameUI" && mode == LoadSceneMode.Additive)
        {
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i] = GameObject.Find("Inv slot " + (i + 1)).GetComponent<InvSlot>();
                inventorySlots[i].OnSlotSelect += SelectSlot;
            }

            foreach (InvSlot slot in inventorySlots)
            {
                slot.Initialize();
            }

            // Get required components to show Item UI wehn player hovers over it in homebase
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            player = GameObject.Find("Player");
            interactableObject = player.GetComponent<InteractableObject>();
            itemUI = GameObject.Find("Item Menu");
            itemUITransform = itemUI.GetComponent<RectTransform>();
            itemsRackTransform = GameObject.Find("Items rack").GetComponent<Transform>();
            backpack = GameObject.Find("Player").GetComponent<Backpack>();

            backpack.OnBackpackSwap += DeactivateActiveSlot;
            interactableObject.OnOverObject += HandleInteraction;
            interactableObject.OnNotOverObject += HandleExitInteraction;

            itemUI.SetActive(false);
        }
    }

    void SelectSlot(string imageOfObjectName, string slotName)
    {
        // we dont care if its already selected
        bool alreadyinbackpack = backpack.isInventoryItemAlreadyInBackpack(imageOfObjectName);
        Debug.Log("Already in backpack? :" + alreadyinbackpack);
        if (slotName != selectedSlot && !alreadyinbackpack)
        {
            DeactivateActiveSlot();
            
            selectedSlot = slotName;
            foreach (InvSlot slot in inventorySlots)
            {
                if (slot.name == slotName)
                {
                    slot.SelectSlot();
                    break;
                }
            }
            backpack.HighlightSlots(imageOfObjectName);
            //Debug.Log("Item selected: " + activeSlot);
        }
    }


    void HandleInteraction(string colliderName)
    {
        if (colliderName == "Items rack")
        {
            // Activate the items UI
            itemUI.SetActive(true);
            backpackOriginalPosition = GameObject.Find("Backpack").GetComponent<RectTransform>().position;
        }
    }

    void HandleExitInteraction(string colliderName)
    {
        if (colliderName == "Items rack")
        {
            //Move the backpack slots back to the corner of the UI
            GameObject.Find("Backpack").GetComponent<RectTransform>().position = backpackOriginalPosition;
            // Deactivate the inventory menu
            itemUI.SetActive(false);
            DeactivateActiveSlot();
            backpack.GreySlots();
        }
    }

    void DeactivateActiveSlot()
    {
        if (selectedSlot != null)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].name == selectedSlot) inventorySlots[i].DeselectSlot();
            }
            selectedSlot = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (itemUI)
        {
            if (player && itemUI.activeSelf)
            {
                Vector3 itemsRackPosition = new Vector3(itemsRackTransform.position.x, 2, 0);
                Vector3 itemsRackPositionScreenPoint = cam.WorldToScreenPoint(itemsRackPosition);
                //Vector3 movingUI = new Vector3(itemsRackPositionX.x, itemUITransform.position.y, 0);
                itemUITransform.position = itemsRackPositionScreenPoint;

                // Move the backpack slots into the UI
                RectTransform objectToFollow = GameObject.Find("Backpack position").GetComponent<RectTransform>();
                Vector3 newPosition = new Vector3(objectToFollow.position.x, objectToFollow.position.y, 0);

                GameObject.Find("Backpack").GetComponent<RectTransform>().position = newPosition;
            }
        }
    }
}
