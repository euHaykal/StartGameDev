using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //trabalha com Canvas

public class DialogueManager : MonoBehaviour  //Classe responsável por pegar as falas e colocar na cena
{
    [Header("Components")]
    public GameObject dialogueObj;  //Janela do diálogo
    public Image profileSprite;  //Referencia a imagem de perfil do personagem que está falando
    public Text speechText;  //Referencia o texto da fala
    public Text actorNameText;  //Referencia o nome do personagem que está falando

    [Header("Settings")]
    public float typingSpeed;  //Referencia a velocidade da fala


    #region Variáveis de Controle

    private bool isShowing;  //Referencia se a janela está visível
    private int index;  //Referencia a quantidade de texto de uma fala
    private string[] senteces;

    #endregion


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    IEnumerator TypeSentence()  //Corrotina - ta confuso
    {
        foreach(char letter in senteces[index].ToCharArray())  //variável local char -> só armazena um caracter; código serve para receber a fala do npc letra por letra
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);  //determina o tempo em que o for roda, logo, a velocidade em quem as palavras aparecem
        }
    }

    public void NextSentece()  //Sereve para pular para a próxima fala
    {

    }

    public void Speech(string[] txt)  //Chama a fala do NPC
    {
        if(!isShowing)  //se isShowing == false -> executa o diálogo uma vez enquanto a booleana é true
        {
            dialogueObj.SetActive(true);  //Faz o objeto aparecer na cena
            senteces = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
