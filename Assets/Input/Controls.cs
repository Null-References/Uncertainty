// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""SpaceShip"",
            ""id"": ""abaa505f-76cd-4a34-a955-f1f5104b4971"",
            ""actions"": [
                {
                    ""name"": ""Steering_mouse"",
                    ""type"": ""Value"",
                    ""id"": ""5ac58c89-e668-48f7-9a08-4554be5d4ea8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Free_Look"",
                    ""type"": ""Button"",
                    ""id"": ""46e05938-b8c1-48fe-9e48-d11c0512c316"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Forward_Backward"",
                    ""type"": ""Button"",
                    ""id"": ""42599a94-9e0f-4379-8866-92d487f10cd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""e93cb68a-16b7-4b9a-a3b2-a3aa18d54dc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1cd9bc77-e24a-4d6e-8521-5008c1cd3514"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Button"",
                    ""id"": ""8116b163-f9e9-49a0-9423-f67b8e4d24cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c540d58-ae8c-4873-8a6b-1980354c1027"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Steering_mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74ab0324-efe4-40df-b958-fe5c56c315bc"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Free_Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Longitudinal"",
                    ""id"": ""cc768e96-56c5-477b-b8c0-e2c563f0d834"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Forward_Backward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c7529756-3c93-4530-a248-2954360383a6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Forward_Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""17d8945f-2383-4ac2-9a5a-f6a3c2fe863d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Forward_Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""roll"",
                    ""id"": ""f141433e-cb35-4250-9a13-2b7250c03c9d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f6793560-3e0e-49ba-8ecd-fa56b4b31078"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f1aabd50-473e-434a-8594-a816bcad1a24"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""deed355a-8a80-4391-9f0d-77363cca2af7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22b72716-03ce-435b-bd4b-1f15cf0e47c1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // SpaceShip
        m_SpaceShip = asset.FindActionMap("SpaceShip", throwIfNotFound: true);
        m_SpaceShip_Steering_mouse = m_SpaceShip.FindAction("Steering_mouse", throwIfNotFound: true);
        m_SpaceShip_Free_Look = m_SpaceShip.FindAction("Free_Look", throwIfNotFound: true);
        m_SpaceShip_Move_Forward_Backward = m_SpaceShip.FindAction("Move_Forward_Backward", throwIfNotFound: true);
        m_SpaceShip_Roll = m_SpaceShip.FindAction("Roll", throwIfNotFound: true);
        m_SpaceShip_Shoot = m_SpaceShip.FindAction("Shoot", throwIfNotFound: true);
        m_SpaceShip_Aiming = m_SpaceShip.FindAction("Aiming", throwIfNotFound: true);
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

    // SpaceShip
    private readonly InputActionMap m_SpaceShip;
    private ISpaceShipActions m_SpaceShipActionsCallbackInterface;
    private readonly InputAction m_SpaceShip_Steering_mouse;
    private readonly InputAction m_SpaceShip_Free_Look;
    private readonly InputAction m_SpaceShip_Move_Forward_Backward;
    private readonly InputAction m_SpaceShip_Roll;
    private readonly InputAction m_SpaceShip_Shoot;
    private readonly InputAction m_SpaceShip_Aiming;
    public struct SpaceShipActions
    {
        private @Controls m_Wrapper;
        public SpaceShipActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steering_mouse => m_Wrapper.m_SpaceShip_Steering_mouse;
        public InputAction @Free_Look => m_Wrapper.m_SpaceShip_Free_Look;
        public InputAction @Move_Forward_Backward => m_Wrapper.m_SpaceShip_Move_Forward_Backward;
        public InputAction @Roll => m_Wrapper.m_SpaceShip_Roll;
        public InputAction @Shoot => m_Wrapper.m_SpaceShip_Shoot;
        public InputAction @Aiming => m_Wrapper.m_SpaceShip_Aiming;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceShipActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionsCallbackInterface != null)
            {
                @Steering_mouse.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSteering_mouse;
                @Steering_mouse.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSteering_mouse;
                @Steering_mouse.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSteering_mouse;
                @Free_Look.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnFree_Look;
                @Free_Look.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnFree_Look;
                @Free_Look.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnFree_Look;
                @Move_Forward_Backward.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMove_Forward_Backward;
                @Move_Forward_Backward.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMove_Forward_Backward;
                @Move_Forward_Backward.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMove_Forward_Backward;
                @Roll.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRoll;
                @Shoot.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnShoot;
                @Aiming.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnAiming;
            }
            m_Wrapper.m_SpaceShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steering_mouse.started += instance.OnSteering_mouse;
                @Steering_mouse.performed += instance.OnSteering_mouse;
                @Steering_mouse.canceled += instance.OnSteering_mouse;
                @Free_Look.started += instance.OnFree_Look;
                @Free_Look.performed += instance.OnFree_Look;
                @Free_Look.canceled += instance.OnFree_Look;
                @Move_Forward_Backward.started += instance.OnMove_Forward_Backward;
                @Move_Forward_Backward.performed += instance.OnMove_Forward_Backward;
                @Move_Forward_Backward.canceled += instance.OnMove_Forward_Backward;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
            }
        }
    }
    public SpaceShipActions @SpaceShip => new SpaceShipActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISpaceShipActions
    {
        void OnSteering_mouse(InputAction.CallbackContext context);
        void OnFree_Look(InputAction.CallbackContext context);
        void OnMove_Forward_Backward(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
    }
}
