using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;  //Referencia a velocidade em que a madeira chega no local final do drop
    [SerializeField] private float timeMove;  //Referencia o tempo que demora para a madeira chegar no local final do drop

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


    private void OnTriggerEnter2D(Collider2D collision)  //Determina colisão com objeto
    {
        if(collision.CompareTag("Player"))  //Caso o jogador colida com o objeto
        {
            collision.GetComponent<PlayerItens>().TotalWood++;  //A quantidade de madeira coletada aumenta 
            Destroy(gameObject);  //E o item é destruído da cena
        }
    }
}
