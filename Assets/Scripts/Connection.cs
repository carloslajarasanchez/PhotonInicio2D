using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Dependencias
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //Cargar las configuracion de la red
        PhotonNetwork.ConnectUsingSettings();// Que se conecte usando la configuracion de la AppID
        PhotonNetwork.AutomaticallySyncScene = true;// Para que actualice la escena automaticamente
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)// Si eres el master y en la sala ya hay alguien
        {
            PhotonNetwork.LoadLevel(1);// Esto instancia la siguiente escena en Photon
            Destroy(this);// Eliminamos esta escena
        }
    }

    // Metodo del boton para conectarse
    public void ButtonConnect()
    {
        // Creamos una habitacion o room
        RoomOptions options = new RoomOptions() { MaxPlayers = 2 };// Asignamos el numero maximo de jugadores
        PhotonNetwork.JoinOrCreateRoom("Moncloa", options, TypedLobby.Default);// Para unirte o crear una room, si ya hay una creada te unes y si no la creas (pasamos el nombre, las opciones, tipo de lobby
    }

    // Metodo para saber si me he conectado a la sala
    public override void OnJoinedRoom()
    {
        Debug.Log($"Me he conectado a la sala {PhotonNetwork.CurrentRoom.Name}");// Para saber el nombre de la sala a la que te conectas
        Debug.Log($"Hay... {PhotonNetwork.CurrentRoom.PlayerCount} jugadores conectados");// Para ver cuantos jugadores hay conectados
    }

    // Metodo de cuando te conectas a la rama master
    public override void OnConnectedToMaster()
    {
        Debug.Log($"Conectado al master");
    }
}
