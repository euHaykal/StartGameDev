using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;  //Referencia a velocidade do movimento do NPC
    private float initialSpeed; //Referencia a velocidade inicial do NPC

    private int index;  //Referencia contagem para determinar em que "path" o NPC está
    private Animator anim;

    public List<Transform> paths = new List<Transform>();  //Referencia os "paths"
    
    void Start()
    {
        initialSpeed = speed;  //Quando a cena é inciciada, o jogo determina que a velocidade inicial é igual a velocidade setada no inspector
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(DialogueManager.istance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);  //Determina a direção que o personagem deve seguir

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)  //Determina se o NPC chegou no "path" -> posição npc - posição do path até dar zero
        {
            if(index < paths.Count - 1)  //checa se o index é menor que o tamanho da lista
            {
                //index++; //enquanto o index é menor q o total vai somando os elementos
                index = Random.Range(0, paths.Count - 1);  //serve para sortear os paths, gerando um caminho "aleatório"
            }
            else
            {
                index = 0;  //quando o index chega no máximo seu valor é zerado, para não dar erro e reiniciar
            }
        }

        Vector2 direction = paths[index].position - transform.position;  //Determina o lado do sprite baseado na direção da movimentação

        if(direction.x >0)  //direita 
        {
            transform.eulerAngles = new Vector2(0,0);
        }

        if(direction.x <0)  //esquerda
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }
}
