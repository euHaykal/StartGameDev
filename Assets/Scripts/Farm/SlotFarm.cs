using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;


    [SerializeField] private int digAmount;  //quantidade de vezes que você tem que cavar para o buraco aparecer
    private int initialDigAmount;

    [SerializeField] private bool isDig;


    public void Start()
    {
        initialDigAmount = digAmount;  //armazena o digamount inicial no digamount
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= initialDigAmount/2)
        {
            spriteRender.sprite = hole;
        }
        // if(digAmount <= 0)
        // {
        //     //Plantar cenoura
        //     spriteRender.sprite = carrot;
        // }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig") && !isDig)
        {
            OnHit();
        }
    }

}
