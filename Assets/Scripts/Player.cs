using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    //private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)// Busca su componente PhotonView (Para saber si es él el jugador)
        {
            //camera = Camera.main;
            rig = GetComponent<Rigidbody>();// Cogemos el rigidbody
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)// Busca su componente PhotonView (Para saber si es él el jugador)
        {
            rig.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rig.velocity.y);// Aplicamos una velocidad al rigidbody con el Input por la velocidad

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector3(Input.GetAxis("Horizontal"), 1, 0) * speed, ForceMode.Impulse);
            }*/
        }
    }
    /*private void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -15);
    }*/
}
