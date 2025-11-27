using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)// si soy el master de la sala
        {
            PhotonNetwork.Instantiate("PlayerA", new Vector3(-6, -3, 0), Quaternion.identity);// Instanciamos un jugador master
        }
        else
        {
            PhotonNetwork.Instantiate("PlayerB", new Vector3(6, 3, 0), Quaternion.identity);// Instanciamos el jugador
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
