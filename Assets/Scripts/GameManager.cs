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
    public List<GameObject> players;
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
                if (players.Count > 1)
                {
                    rbGrandma.isKinematic = false;
                }
            }
        }

        //TP player near grandma if there distance is to big
        for (int i = 0; i < players.Count; i++)
        {
            float playerDistance = Vector3.Distance(players[i].transform.position, grandma.transform.position);
            if (playerDistance > playerDistanceTP)
            {
                players[i].transform.position = grandma.transform.position + Vector3.back * 2f;
            }
        }
    }



    //Loose the game

    //Win the game

}
