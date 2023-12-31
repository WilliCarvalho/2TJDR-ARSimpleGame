//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputSystem/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Behaviours"",
            ""id"": ""fb1d889d-e378-4e98-9653-41bd05e13642"",
            ""actions"": [
                {
                    ""name"": ""Firing"",
                    ""type"": ""Button"",
                    ""id"": ""308b3fdc-802f-4e4e-bf9a-89f0a914a498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7976dec9-2f0b-4954-910d-96f2a7a87789"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Firing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Behaviours
        m_Behaviours = asset.FindActionMap("Behaviours", throwIfNotFound: true);
        m_Behaviours_Firing = m_Behaviours.FindAction("Firing", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Behaviours
    private readonly InputActionMap m_Behaviours;
    private List<IBehavioursActions> m_BehavioursActionsCallbackInterfaces = new List<IBehavioursActions>();
    private readonly InputAction m_Behaviours_Firing;
    public struct BehavioursActions
    {
        private @PlayerControls m_Wrapper;
        public BehavioursActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Firing => m_Wrapper.m_Behaviours_Firing;
        public InputActionMap Get() { return m_Wrapper.m_Behaviours; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BehavioursActions set) { return set.Get(); }
        public void AddCallbacks(IBehavioursActions instance)
        {
            if (instance == null || m_Wrapper.m_BehavioursActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BehavioursActionsCallbackInterfaces.Add(instance);
            @Firing.started += instance.OnFiring;
            @Firing.performed += instance.OnFiring;
            @Firing.canceled += instance.OnFiring;
        }

        private void UnregisterCallbacks(IBehavioursActions instance)
        {
            @Firing.started -= instance.OnFiring;
            @Firing.performed -= instance.OnFiring;
            @Firing.canceled -= instance.OnFiring;
        }

        public void RemoveCallbacks(IBehavioursActions instance)
        {
            if (m_Wrapper.m_BehavioursActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBehavioursActions instance)
        {
            foreach (var item in m_Wrapper.m_BehavioursActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BehavioursActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BehavioursActions @Behaviours => new BehavioursActions(this);
    public interface IBehavioursActions
    {
        void OnFiring(InputAction.CallbackContext context);
    }
}
