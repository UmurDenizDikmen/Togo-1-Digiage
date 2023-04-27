using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public GameObject backGround;
    private  float speed;
    public Animator playerAnim;

    private void Start()
    {
        GameManager.onStateChanged += OnStateChanged;
    }

    private void Update()
    {
        playerAnim.speed=speed;
        if (backGround.activeInHierarchy)
        {
            playerAnim.SetBool("Walk", true);
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }
    private void OnStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                 speed = 0;
                break;

            case GameState.InGame:
               speed = 5;
                break;
                case GameState.Vending :
                speed = 0;
                break;
        }
    }
}

