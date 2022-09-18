// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Concretes/Inputs/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""92daa187-b33c-4389-bee7-27bdf642f907"",
            ""actions"": [
                {
                    ""name"": ""TouchH"",
                    ""type"": ""PassThrough"",
                    ""id"": ""20eec609-61f9-480d-801f-2ebadd39e055"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""23cef57e-e25a-4e8e-8fba-12140358cf38"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""TouchV"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ee24609e-d646-4567-b6a1-cfb39c5baa13"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4ee51912-07db-4c0b-95ae-94ac13588c7d"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""350d10df-60d3-4661-8fce-a0d43c2452b2"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d98d844-f877-4800-b7d5-529bb2f54ddc"",
                    ""path"": ""<Touchscreen>/delta/y"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchV"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_TouchH = m_Touch.FindAction("TouchH", throwIfNotFound: true);
        m_Touch_TouchInput = m_Touch.FindAction("TouchInput", throwIfNotFound: true);
        m_Touch_TouchV = m_Touch.FindAction("TouchV", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_TouchH;
    private readonly InputAction m_Touch_TouchInput;
    private readonly InputAction m_Touch_TouchV;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchH => m_Wrapper.m_Touch_TouchH;
        public InputAction @TouchInput => m_Wrapper.m_Touch_TouchInput;
        public InputAction @TouchV => m_Wrapper.m_Touch_TouchV;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @TouchH.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchH;
                @TouchH.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchH;
                @TouchH.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchH;
                @TouchInput.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                @TouchV.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchV;
                @TouchV.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchV;
                @TouchV.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchV;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchH.started += instance.OnTouchH;
                @TouchH.performed += instance.OnTouchH;
                @TouchH.canceled += instance.OnTouchH;
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchV.started += instance.OnTouchV;
                @TouchV.performed += instance.OnTouchV;
                @TouchV.canceled += instance.OnTouchV;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnTouchH(InputAction.CallbackContext context);
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchV(InputAction.CallbackContext context);
    }
}
