using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public delegate void SelectItemEvent(string imageOfObjectName, string slotName);
    public event SelectItemEvent OnSlotSelect;

    // Used to determine if slot has something in it
    public bool isSlotActive = false;
    // The slot number found in the name of this gameObject
    public int slotNumber;
    // Each Inv slot has a designate item. This is set in the inspector
    public GameObject imageOfObject;

    private Image background;

    private void OnEnable()
    {
        name = gameObject.name;
        background = GetComponent<Image>();
        slotNumber = int.Parse(name.Substring(name.Length - 1));
    }

    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (isSlotActive)
        {
            OnSlotSelect?.Invoke(imageOfObject.name, name);
        }
    }

    public void Initialize()
    {
        //Debug.Log("InvSlot: My imageOfObject name is: " + imageOfObject.name);
        if (GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>().GetUnlockedObjectStatus(imageOfObject.name))
        {
            isSlotActive = true;
            Instantiate(imageOfObject, GetComponent<RectTransform>());
        }
    }

    public void DeselectSlot()
    {
        background.color = new Color(96f/255f, 96f/255f, 96f/255f);
    }

    public void SelectSlot()
    {
        background.color = new Color32(21, 0, 255, 255);
    }
}
