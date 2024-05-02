using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData_", menuName = "UnitData/Player")]
public class PlayerMovementData : ScriptableObject
{
    [Tooltip("What's your name?")]
    [SerializeField]
    private string _name = "...";

    [Tooltip("Insert player camera here")]
    public Camera playerCamera;

    [Header("Movement Speed")]
    [SerializeField]
    [Range(1, 50)]
    public float walkSpeed = 6f;
    [SerializeField]
    [Range(1, 100)]
    public float runSpeed = 12f;

    [Header("Weeeee")]
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How strong are your legs?")]
    public float jumpPower = 7f;
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How strong is gravity?")]
    public float gravity = 10f;

    [Header("Camera Movement")]
    [Tooltip("How fast you can turn your head")]
    public float lookSpeed = 2f;
    [Tooltip("How far you can turn your head")]
    public float lookXLimit = 45f;

    [Header("Can I move?")]
    public bool canMove = true;
}
