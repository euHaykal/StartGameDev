using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;  //variável para detectar se o jogador está em contato ou não com a água
    [SerializeField] private int waterValue;
    
    private PlayerItens player;  //variável para poder acessar os scripts do jogador


    void Start()
    {
        player = FindObjectOfType<PlayerItens>();  //quando o jogo começa, a variável busca pelo script de itens no objeto player
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))  //se detectingPlayer == true e botão 'E' sendo apertado
        {
            player.WaterLimit(waterValue);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)  //detecta se o collider do player estiver em contato com o da água
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //detecta se o collider do player não estiver em contato com o da água
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
