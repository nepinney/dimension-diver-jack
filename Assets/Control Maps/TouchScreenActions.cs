// GENERATED AUTOMATICALLY FROM 'Assets/Control Maps/TouchScreenActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchScreenActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchScreenActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchScreenActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ba1bf7de-5aeb-4403-a968-c2b68b02a42e"",
            ""actions"": [
                {
                    ""name"": ""TouchPressOne"",
                    ""type"": ""Button"",
                    ""id"": ""1abed503-a489-4010-ab25-85122f945c3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPositionOne"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c655ae1c-0e74-480b-bd88-aaf20333f65b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPressTwo"",
                    ""type"": ""Button"",
                    ""id"": ""1d53a923-da16-4417-9eea-a9082a9f038e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPositionTwo"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9c78ef5b-875e-4c39-aac9-748ca481a30a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d3714c7-a7fc-4db3-9154-eca39ffa4f28"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPositionOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c2cdb15-fe0f-4ed2-bf8c-20e8832a868c"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPositionTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ee13a03-77cc-4b79-bd1f-9c94e4f3ed1e"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPressTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd874e4-fd50-4d17-a3c9-aa34850fbea7"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPressOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_TouchPressOne = m_Player.FindAction("TouchPressOne", throwIfNotFound: true);
        m_Player_TouchPositionOne = m_Player.FindAction("TouchPositionOne", throwIfNotFound: true);
        m_Player_TouchPressTwo = m_Player.FindAction("TouchPressTwo", throwIfNotFound: true);
        m_Player_TouchPositionTwo = m_Player.FindAction("TouchPositionTwo", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_TouchPressOne;
    private readonly InputAction m_Player_TouchPositionOne;
    private readonly InputAction m_Player_TouchPressTwo;
    private readonly InputAction m_Player_TouchPositionTwo;
    public struct PlayerActions
    {
        private @TouchScreenActions m_Wrapper;
        public PlayerActions(@TouchScreenActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPressOne => m_Wrapper.m_Player_TouchPressOne;
        public InputAction @TouchPositionOne => m_Wrapper.m_Player_TouchPositionOne;
        public InputAction @TouchPressTwo => m_Wrapper.m_Player_TouchPressTwo;
        public InputAction @TouchPositionTwo => m_Wrapper.m_Player_TouchPositionTwo;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @TouchPressOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressOne;
                @TouchPressOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressOne;
                @TouchPressOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressOne;
                @TouchPositionOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionOne;
                @TouchPositionOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionOne;
                @TouchPositionOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionOne;
                @TouchPressTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressTwo;
                @TouchPressTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressTwo;
                @TouchPressTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPressTwo;
                @TouchPositionTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionTwo;
                @TouchPositionTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionTwo;
                @TouchPositionTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPositionTwo;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPressOne.started += instance.OnTouchPressOne;
                @TouchPressOne.performed += instance.OnTouchPressOne;
                @TouchPressOne.canceled += instance.OnTouchPressOne;
                @TouchPositionOne.started += instance.OnTouchPositionOne;
                @TouchPositionOne.performed += instance.OnTouchPositionOne;
                @TouchPositionOne.canceled += instance.OnTouchPositionOne;
                @TouchPressTwo.started += instance.OnTouchPressTwo;
                @TouchPressTwo.performed += instance.OnTouchPressTwo;
                @TouchPressTwo.canceled += instance.OnTouchPressTwo;
                @TouchPositionTwo.started += instance.OnTouchPositionTwo;
                @TouchPositionTwo.performed += instance.OnTouchPositionTwo;
                @TouchPositionTwo.canceled += instance.OnTouchPositionTwo;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnTouchPressOne(InputAction.CallbackContext context);
        void OnTouchPositionOne(InputAction.CallbackContext context);
        void OnTouchPressTwo(InputAction.CallbackContext context);
        void OnTouchPositionTwo(InputAction.CallbackContext context);
    }
}
