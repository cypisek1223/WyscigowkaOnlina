using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
 

public class OnlinePlayer : MonoBehaviourPunCallbacks
{
    public static GameObject LocalPlayer;



    private void Awake()
    {
        if (photonView.IsMine)
        {

            LocalPlayer = gameObject;
        }
        else
        {
            string PlayerName = null;
            Color PlayerColor = Color.white;

            //do uzupelnienia 

        if(photonView.InstantiationData != null)
            {
                PlayerName = (string)photonView.InstantiationData[0];
                PlayerColor = MeniController.IntToColor(
                     (int)photonView.InstantiationData[1],
                     (int)photonView.InstantiationData[2],
                     (int)photonView.InstantiationData[3]
                     );



            }
        }
    }

}
