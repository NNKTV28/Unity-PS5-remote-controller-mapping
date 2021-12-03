using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BirdPlayer : MonoBehaviour
{
    // Movement speed
    public static float speed = 2;
    public float force = 300;
    public static float vidas = 3;
    public Text Lives; 
    public GameObject GameOverText;
    public Text NumeroDeSaltosTexto;
    private float NumeroDeSaltos;
    public float MetrosRecorridos;
    public Transform Player;
    public Text MetrosRecorridosTexto;
    

    // Use this for initialization
    void Start()
    {
        MetrosRecorridos = 0;
        NumeroDeSaltos = 0;
        // Fly towards the right
        //GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        MetrosRecorridos = Vector3.Distance(Player.position, transform.position);
        MetrosRecorridosTexto.text = "Metros recorridos:  " + MetrosRecorridos;
        
        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);

        Lives.text = "Vidas: " + vidas;
        
        if (vidas == 3)
        {
            Lives.GetComponent<Text>().color = Color.green;
        }
        if (vidas == 2)
        {
            Lives.GetComponent<Text>().color = Color.yellow;
        }
        if (vidas == 1)
        {
            Lives.GetComponent<Text>().color = Color.red;
        }

        if (vidas == 0)
        {
            GameOverText.GetComponent<Text>().color = Color.red;
            Time.timeScale = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NumeroDeSaltos = NumeroDeSaltos + 1;
            NumeroDeSaltosTexto.text = "Numero de saltos: " + NumeroDeSaltos;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            print("Has muerto");
        }
    }

    // Called when a collision occurs (ie. Bird hits the ground, or a object)
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        vidas = vidas - 1;
        // Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}