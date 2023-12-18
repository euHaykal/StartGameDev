using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;  //Variável referente ao tamanho do colisor
    public LayerMask playerLayer;  //Variável referente a layer específica do jogador

    public DialogueSettings dialogue;  //Variável referente ao código DialogueSettings

    private bool playerHit;  //Variável referente a "colisão" do jogador com o NPC

    private List<string> sentences = new List<string>();


    void Start()
    {
        GetNPCInfo();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)  //Se o player estiver dentro do range e apertar o botão 'E'
        {
            DialogueManager.istance.Speech(sentences.ToArray());  //Converte a lista para um Array
        }
    }


    void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)  //Está checando a quantidade de falas presente na lista criada no DialogueManager
        {
            sentences.Add(dialogue.dialogues[i].sentece.portuguese);  //Adiciona uma nova sentença ao Arrey de falas(?)
        }
    }


    void FixedUpdate()
    {
        ShowDialogue();
    }


    void ShowDialogue()  //colisor via código
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)  //Se o jogadorr entrar no range do collider2D acontece o que está no if
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueManager.istance.dialogueObj.SetActive(false);
        }
    }


    private void OnDrawGizmosSelected()  //Gizmo é um icone que auxilia na visão do objeto como um todo
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);  //Desenha a esfera que permite ver o range do Collider2D
    }
}
