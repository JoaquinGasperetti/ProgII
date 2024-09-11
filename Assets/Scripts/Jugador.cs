using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        

    }

    // Update is called once per frame


    public float speed = 100f;
    float MovimientoHorizontal;

    void Update()
    {
        MovimientoHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(MovimientoHorizontal * speed * Time.deltaTime, 0, 0);
        
    }
}
