using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class ControllerShip : MonoBehaviour
{
    public float speed = 5f;
    public GameObject ExplosionShip;
    public GameObject Laser;

    private Vector2 move;
    private Rigidbody2D rb;


    //Inicio Variaveis Tamanho da tela
    private Rect cameraRect;
    private float shipWidth;
    private float shipHeight;
    //Fim variaveis Tamanho da tela

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();// rigdbody do player
        SpriteRenderer renderer = rb.GetComponent<SpriteRenderer>(); //size do tamanho da nave

        shipWidth = renderer.bounds.size.x / 2;
        shipHeight = renderer.bounds.size.y / 2;

        Vector3 offset = new Vector3(shipWidth, shipHeight, 0);
        Vector3 topRigthPoint = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);
        Vector3 bottom = Camera.main.ScreenToWorldPoint(Vector3.zero) + offset;
        Vector3 top = Camera.main.ScreenToWorldPoint(topRigthPoint) - offset;

        float largura = top.x - bottom.x;
        float altura = top.y - bottom.y;

        cameraRect = new Rect(
        bottom.x,
        bottom.y,
        top.x - bottom.x,
        top.y - bottom.y
        );
    }

    //Atualizar 60frames por segundo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax);
        float y = Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax);
        transform.position = new Vector3(x, y);
    }
    //INICIO Movimento
    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    //FIM Move

    //Inicio Explosion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.instance.GameOver();
        GameObject boom = Instantiate(ExplosionShip,transform.position,transform.rotation);
        Destroy(boom,0.7f);
        Destroy(gameObject);
    
    }
    //Fim Explosion

    void Shoot() { 
    Vector3 offset = new Vector3(0, shipHeight,0);
    Vector3 position = transform.position + offset;
        GameObject shot = Instantiate(Laser, position, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5 , ForceMode2D.Impulse);
        Destroy(shot, 3);
    }


}
