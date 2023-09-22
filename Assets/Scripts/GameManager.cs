using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the script Manager of the game
 * It makes the game start only when the 2 player are connected
 */
public class GameManager : MonoBehaviour
{
    #region Grandma
    public GameObject grandma;
    public Rigidbody rbGrandma;
    #endregion

    #region Players
    public List<GameObject> playersObj = new List<GameObject>();
    public Material player2Material;
    #endregion

    [SerializeField] private float playerDistanceTP;

    private void Update()
    {
        //Make the grandma move only when the 2 players are connected
        if (grandma != null)
        {
            rbGrandma = grandma.GetComponent<Rigidbody>();
            if (rbGrandma.isKinematic)
            {
                if (playersObj.Count > 1)
                {
                    playersObj[1].GetComponent<PlayerController>().meshRenderer.material = player2Material;
                    rbGrandma.isKinematic = false;
                }
            }
        }

        //TP player near grandma if there distance is to big
        for (int i = 0; i < playersObj.Count; i++)
        {
            float playerDistance = Vector3.Distance(playersObj[i].transform.position + Vector3.back * 8f, grandma.transform.position);
            if (playerDistance > playerDistanceTP)
            {
                playersObj[i].transform.position = grandma.transform.position + Vector3.back * 2f;
            }
        }
    }



    //Loose the game

    //Win the game

}
