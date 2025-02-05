﻿using UnityEngine;

namespace GameCore.Input
{
    public class InputState
    {
        public Vector2 moveVector;
        public Vector2 camera;

        public PressState jump;
        public PressState crouch;
        public PressState sneak;
        public PressState interact;
        public PressState changeCharacter;

        public void Clear()
        {
            moveVector = Vector2.zero;
            camera = Vector2.zero;

            jump = PressState.Released;
            crouch = PressState.Released;
            sneak = PressState.Released;
            interact = PressState.Released;
            changeCharacter = PressState.Released;
        }
    }
}