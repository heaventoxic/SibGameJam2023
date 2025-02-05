﻿using UnityEngine;

namespace GameCore.Character.Movement
{
    [CreateAssetMenu(fileName = "Character Parameters")]
    public class CharacterParameters : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] public float speed;
        [SerializeField] [Range(0f, 1f)] public float crouchSpeedMultiplier;
        [SerializeField] [Range(0f, 1f)] public float crouchHeightMultiplier;
        [SerializeField] [Range(0f, 1f)] public float sneakSpeedMultiplier;

        [Header("Camera")]
        [SerializeField] public float cameraHeight;
        
        [Header("Jump")]
        [SerializeField] public bool canJump;
        [SerializeField] public float jumpHeight;
        [SerializeField] public float inAirSpeed;
        [SerializeField] public float gravityMultiplier;

        [Header("Inertia")]
        [SerializeField] public float lerpInertiaSpeed;

        [Header("Floating")]
        [SerializeField] public float springForce;
        [SerializeField] public float dampingForce;
    }
}