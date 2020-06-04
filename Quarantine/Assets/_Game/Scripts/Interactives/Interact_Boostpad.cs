using UnityEngine;
using System.Collections;

public class Interact_Boostpad : MonoBehaviour
{
    public float boostAmount = 20f;
    public AudioClip boostSound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
        if (player)
        {
            player.BoostJump(boostAmount, boostSound);
        }
    }
}
