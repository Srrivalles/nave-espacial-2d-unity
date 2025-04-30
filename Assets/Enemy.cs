using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int points;
    public GameObject ExplosionShip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.UpdateScore(points);
        GameObject boom = Instantiate(ExplosionShip, transform.position, transform.rotation);
        Destroy(boom, 0.7f);
        Destroy(gameObject);
    }
}
