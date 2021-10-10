// GENERATED AUTOMATICALLY FROM 'Assets/Control Maps/KeyboardActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KeyboardActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0405b30a-a147-4c9b-9eb2-9e6ed8aaad45"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""991a0ee0-6ad6-4443-a07a-e773ea549878"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4bdec5af-d717-4cf4-ba99-ac2409cd4969"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPressOne"",
                    ""type"": ""Button"",
                    ""id"": ""3ba79c08-2363-49f4-b13d-e02b4b2b15fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPositionOne"",
                    ""type"": ""PassThrough"",
                    ""id"": ""92a62b14-c1a9-4be2-a1c3-e8117999b5fc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPressTwo"",
                    ""type"": ""Button"",
                    ""id"": ""4668aeee-4875-45b5-b5fd-695dd918b064"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPositionTwo"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d2af91b7-5cf2-44c0-a5a1-6920da1e801b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""c241027b-4cce-44d3-98f1-aece7822790a"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c98cf726-881f-4115-bee9-c247fbaf865f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9b34db8e-fa6c-41b6-933d-2295431556e1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e47290a-7ca9-4b2c-b937-b6794b120881"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""992fef57-7d9a-44c0-bf56-2663fe722fa4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""29d294a4-dacf-48cb-9ee3-b46170b01fa8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57be7a75-6237-4cbf-a92b-1d1ccd8a5daf"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPressOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01e91443-7dbe-41a4-a81e-396582458327"",
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
                    ""id"": ""268e3a25-7041-4f37-afa3-9958a4b679ce"",
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
                    ""id"": ""a919dbda-017e-433a-9960-5b0b40aeee20"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPressTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameState"",
            ""id"": ""c98ec19c-92d8-44bb-a503-4f984a52f709"",
            ""actions"": [
                {
                    ""name"": ""PauseResume"",
                    ""type"": ""Button"",
                    ""id"": ""b5d7db46-21ea-48c1-88cc-9efb8607f2d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b31ca0f6-40e0-4e06-84d7-80f1b2507daf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
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
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_TouchPressOne = m_Player.FindAction("TouchPressOne", throwIfNotFound: true);
        m_Player_TouchPositionOne = m_Player.FindAction("TouchPositionOne", throwIfNotFound: true);
        m_Player_TouchPressTwo = m_Player.FindAction("TouchPressTwo", throwIfNotFound: true);
        m_Player_TouchPositionTwo = m_Player.FindAction("TouchPositionTwo", throwIfNotFound: true);
        // GameState
        m_GameState = asset.FindActionMap("GameState", throwIfNotFound: true);
        m_GameState_PauseResume = m_GameState.FindAction("PauseResume", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_TouchPressOne;
    private readonly InputAction m_Player_TouchPositionOne;
    private readonly InputAction m_Player_TouchPressTwo;
    private readonly InputAction m_Player_TouchPositionTwo;
    public struct PlayerActions
    {
        private @KeyboardActions m_Wrapper;
        public PlayerActions(@KeyboardActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
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
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
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
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
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

    // GameState
    private readonly InputActionMap m_GameState;
    private IGameStateActions m_GameStateActionsCallbackInterface;
    private readonly InputAction m_GameState_PauseResume;
    public struct GameStateActions
    {
        private @KeyboardActions m_Wrapper;
        public GameStateActions(@KeyboardActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseResume => m_Wrapper.m_GameState_PauseResume;
        public InputActionMap Get() { return m_Wrapper.m_GameState; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameStateActions set) { return set.Get(); }
        public void SetCallbacks(IGameStateActions instance)
        {
            if (m_Wrapper.m_GameStateActionsCallbackInterface != null)
            {
                @PauseResume.started -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPauseResume;
                @PauseResume.performed -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPauseResume;
                @PauseResume.canceled -= m_Wrapper.m_GameStateActionsCallbackInterface.OnPauseResume;
            }
            m_Wrapper.m_GameStateActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseResume.started += instance.OnPauseResume;
                @PauseResume.performed += instance.OnPauseResume;
                @PauseResume.canceled += instance.OnPauseResume;
            }
        }
    }
    public GameStateActions @GameState => new GameStateActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTouchPressOne(InputAction.CallbackContext context);
        void OnTouchPositionOne(InputAction.CallbackContext context);
        void OnTouchPressTwo(InputAction.CallbackContext context);
        void OnTouchPositionTwo(InputAction.CallbackContext context);
    }
    public interface IGameStateActions
    {
        void OnPauseResume(InputAction.CallbackContext context);
    }
}
