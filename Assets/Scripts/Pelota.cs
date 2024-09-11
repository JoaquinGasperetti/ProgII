using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Pelota : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector2 VelocidadInicial;
    private Rigidbody2D pelotitaRB;
    bool IsMooving;
    private int puntos;
    public Text PuntuacionText;
    private int nivel;

    void Start()
    {
        pelotitaRB = GetComponent<Rigidbody2D>();
        puntos = 0;
        nivel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMooving)
        {
            pelotitaRB.velocity = VelocidadInicial;
            IsMooving = true;
        }

        Victoria();
        
    }

    private void OnCollisionEnter2D(Collision2D choque)
    {
        if (choque.gameObject.CompareTag("Ladrillo"))
        {
            Destroy(choque.gameObject);
            puntos++;
            PuntuacionText.text = "Puntos: " + puntos;
        }

        if (choque.gameObject.CompareTag("Death"))
        {
            GameOver();
        }
    }

    void Victoria()
    {
        GameObject[] ladrillos = GameObject.FindGameObjectsWithTag("Ladrillo");
        if(ladrillos.Length == 0 && nivel == 1)
        {
            nivel = 2;
            SceneManager.LoadScene("Nivel2");
        }

        if(ladrillos.Length == 0 && nivel == 2)
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("derrota");
    }
}
