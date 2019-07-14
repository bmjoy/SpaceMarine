﻿using System;
using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.Dialog;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorTerminalDialog : UiGameEventListener
    {
        private IElevator Elevator => GameController.Instance.Game.ElevatorMechanics.Elevator;
        private UiButtonTriggerZone ButtonETrigger { get; set; }
        
        [Header("Dialog Parameters")]
        public TextButton ButtonToggleOn;
        public TextButton ButtonToggleOff;
        public TextSequence TextSequenceOn;
        public TextSequence TextSequenceOff;
        private IDialogSystem DialogSystem { get; set; }

        protected override void Awake()
        {
            base.Awake();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
            ButtonToggleOn.OnPress.AddListener(ToggleElevator);
            ButtonToggleOff.OnPress.AddListener(ToggleElevator);
        }

        private void Start()
        {
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if (!DialogSystem.IsOpened)
            {
                if(Elevator.IsLocked)
                    DialogSystem.Write(TextSequenceOff);
                else
                    DialogSystem.Write(TextSequenceOn);
            }
            else
                DialogSystem.Hide();
        }
        
        void ToggleElevator()
        {
            Elevator.Switch();
        }
    }
}