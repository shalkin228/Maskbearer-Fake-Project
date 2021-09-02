// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Basic Mehanicks/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""cbd6bab1-4b7c-4e1d-932a-decacc616cd1"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""857d4b71-b84b-4c12-ad58-3e157f5da935"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""df6659be-ee2a-4c3c-9b3e-e7f2e4e179c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookDown"",
                    ""type"": ""Button"",
                    ""id"": ""d9c39bae-8053-4820-a54f-cb10c0e18a0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookUp"",
                    ""type"": ""Button"",
                    ""id"": ""c26270a7-bee2-47de-ad53-81fc1ebfd2df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hit"",
                    ""type"": ""Button"",
                    ""id"": ""cbd39b0b-d247-4d02-b6dc-be5c34cf0219"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""beb496b7-c592-4057-a93e-1017b9f4f190"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Controller"",
                    ""id"": ""82a631c1-1e9e-4b21-a31e-adfd0de71d90"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9500dfec-11ce-4822-b520-0042a7919ae8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ba4f736a-be19-4b28-b504-7560ac8a270d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d8006e9b-425e-4d6b-86ff-3f82c8cd0856"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3bee5513-a988-46cd-86a6-b6cfef86dfe7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ef580fbd-910b-4459-9552-557e92ba2578"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""710f15f7-8a86-42ce-8ea5-c5b588fa3c27"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d350d1a-bb0c-40b7-adb8-f55f76feac2d"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f1c4b3d-f287-4505-ba66-370f59b462d4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0dfe3be-1efb-483b-82e7-b4b3b5f6ae30"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""553420bf-70b4-4ade-a7a9-70dda9c69ff4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb3e893f-523b-44da-94e2-d04ea91cecc4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""091a168e-2fdb-4bc9-8435-9301a0c7f9ef"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecad759d-dcda-4b02-9430-39777a9d2c6d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc40419a-9ab4-4691-af5f-92b13ff5428b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d26a513-862b-46f9-b715-b495ac05679e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Horizontal = m_PlayerInput.FindAction("Horizontal", throwIfNotFound: true);
        m_PlayerInput_Jump = m_PlayerInput.FindAction("Jump", throwIfNotFound: true);
        m_PlayerInput_LookDown = m_PlayerInput.FindAction("LookDown", throwIfNotFound: true);
        m_PlayerInput_LookUp = m_PlayerInput.FindAction("LookUp", throwIfNotFound: true);
        m_PlayerInput_Hit = m_PlayerInput.FindAction("Hit", throwIfNotFound: true);
        m_PlayerInput_Exit = m_PlayerInput.FindAction("Exit", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_Horizontal;
    private readonly InputAction m_PlayerInput_Jump;
    private readonly InputAction m_PlayerInput_LookDown;
    private readonly InputAction m_PlayerInput_LookUp;
    private readonly InputAction m_PlayerInput_Hit;
    private readonly InputAction m_PlayerInput_Exit;
    public struct PlayerInputActions
    {
        private @Player m_Wrapper;
        public PlayerInputActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_PlayerInput_Horizontal;
        public InputAction @Jump => m_Wrapper.m_PlayerInput_Jump;
        public InputAction @LookDown => m_Wrapper.m_PlayerInput_LookDown;
        public InputAction @LookUp => m_Wrapper.m_PlayerInput_LookUp;
        public InputAction @Hit => m_Wrapper.m_PlayerInput_Hit;
        public InputAction @Exit => m_Wrapper.m_PlayerInput_Exit;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @LookDown.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookDown;
                @LookDown.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookDown;
                @LookDown.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookDown;
                @LookUp.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookUp;
                @LookUp.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookUp;
                @LookUp.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnLookUp;
                @Hit.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHit;
                @Hit.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHit;
                @Hit.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHit;
                @Exit.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LookDown.started += instance.OnLookDown;
                @LookDown.performed += instance.OnLookDown;
                @LookDown.canceled += instance.OnLookDown;
                @LookUp.started += instance.OnLookUp;
                @LookUp.performed += instance.OnLookUp;
                @LookUp.canceled += instance.OnLookUp;
                @Hit.started += instance.OnHit;
                @Hit.performed += instance.OnHit;
                @Hit.canceled += instance.OnHit;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    public interface IPlayerInputActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLookDown(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnHit(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
