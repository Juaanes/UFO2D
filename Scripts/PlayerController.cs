using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    TextMeshProUGUI text2;

    [SerializeField]
    TextMeshProUGUI text3;

    [SerializeField]
    float speed;

    int puntuacio = 0;

    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        //text2 No es visible
        text2.gameObject.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();

        //Text3 No es visible
        text3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Codi de moviment del 'player'
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //El sprite amb l'etiqueta "pickup" quan colisiona fa el codi
        if (collision.tag == "Pickup")
        {
       
            //suma pickup
            puntuacio++;
            //Debug.Log("Puntuacio: " + puntuacio);
            text.text = puntuacio.ToString();
            
            //Elimina PickUp
            collision.gameObject.SetActive(false);

            if (puntuacio == 4)
            {
                //Text de "HAS GUANYAT"
                text2.gameObject.SetActive(true);
               
                //Text de presionar "ESC" per sortir
                text3.gameObject.SetActive(true);
            }


        }
    }
    private void LateUpdate()
    {
       //Codic per sortir del joc
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           Application.Quit();
       }
    }
}
