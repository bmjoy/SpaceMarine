﻿using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiArrivalRoom : UiRoom
    {
        [Tooltip("Position of the camera in this room.")] [SerializeField]
        protected Transform CameraPosition;
        
        private void Start()
        {
            GameCamera.Instance.Motion.Teleport(CameraPosition.position);
        }
    }
}