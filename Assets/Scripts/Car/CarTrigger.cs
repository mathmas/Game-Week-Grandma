using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script verify the object in front of the car
 * It's used to stop the car when the player press Action1 button
 * It's also used for the cars to not run into each others
 * The player can't make the cars wait to long or they will just run into the player
 */

public class CarTrigger : MonoBehaviour
{
    #region Scripts Vars
    CarBehaviour carBehaviour;
    PlayerController playerController;
    #endregion

    #region Time Var
    public float maxWaitTime;
    public float restWaitTime;
    #endregion

    private void Start()
    {
        carBehaviour = GetComponentInParent<CarBehaviour>();
        restWaitTime = maxWaitTime;
    }

    //Stop moving if a player is stoping
    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            playerController = col.GetComponent<PlayerController>();

            if(playerController.stopActionInput && restWaitTime > 0) 
            {
                if(carBehaviour.speed > 1f)
                {
                    carBehaviour.PlayerStopSound();
                }
                carBehaviour.speed = 0f;
            }
            else
            {
                carBehaviour.speed = carBehaviour.maxSpeed;
            }
        }
    }

    private void LateUpdate()
    {
        if(carBehaviour.speed < 1)
        {
            restWaitTime -= Time.deltaTime;

            if (restWaitTime < 0)
            {
                carBehaviour.speed = carBehaviour.maxSpeed;
            }
            else if (restWaitTime < 0.5f)
            {
                carBehaviour.CarHornAudio();
            }
        }
    }

    //The car doesnt run into each other
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.speed = 0f;
            carBehaviour.animator.SetBool("isMoving", false);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.speed = carBehaviour.maxSpeed;
            carBehaviour.animator.SetBool("isMoving", true);
        }
    }
}
