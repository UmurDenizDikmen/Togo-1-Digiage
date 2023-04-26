using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public GameObject backGround;
    public float speed;
    public Animator playerAnim;

    void Update()
    {
        if (backGround.activeInHierarchy)
        {
            playerAnim.SetBool("isRunning", true);
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
    }
}
