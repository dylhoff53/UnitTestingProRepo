using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMover : MonoBehaviour, ICharacterMover
{
    private CharacterController characterController;

    private new Transform transform;

    public Material playerMaterial;
    public Material NPCMaterial;

    [SerializeField]
    private bool isPlayer;

    public bool IsPlayer => isPlayer;

    public int Health { get; set; }

    public int Color { get; set; }

    public float Size { get; set; }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Size = 1f;
        transform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, 0, vertical));
        transform.localScale = new Vector3(Size, Size, Size);
        if(Color == 1)
        {
            GetComponent<Renderer>().material = playerMaterial;
        } else if (Color == 2)
        {
            GetComponent<Renderer>().material = NPCMaterial;
        }
    }
}
