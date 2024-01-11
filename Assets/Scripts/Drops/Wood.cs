using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;


    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;  //Quando a madeira for instanciada imediatamente vai inicializar o contador

        if(timeCount < timeMove)  //Enquanto o contador for menor ele move o objeto
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);  
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItens>().TotalWood++;
            Destroy(gameObject);
        }
    }
}
