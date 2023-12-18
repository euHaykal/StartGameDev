using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;  //trabalha com Canvas

public class DialogueManager : MonoBehaviour  //Classe responsável por pegar as falas e colocar na cena
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng
    }

    public idiom language;


    [Header("Components")]
    public GameObject dialogueObj;  //Janela do diálogo
    public Image profileSprite;  //Referencia a imagem de perfil do personagem que está falando
    public TMP_Text speechText;  //Referencia o texto da fala
    public TMP_Text actorNameText;  //Referencia o nome do personagem que está falando

    [Header("Settings")]
    public float typingSpeed;  //Referencia a velocidade da fala


    #region Variáveis de Controle

    private bool isShowing;  //Referencia se a janela está visível
    private int index;  //Referencia a quantidade de texto de uma fala
    private string[] senteces;

    public static DialogueManager istance;

    private void Awake()  //Awake é chamada antes de todos os Start() na hierarquia de execução de scrripts
    {
        istance = this;
    }

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
        if(speechText.text == senteces[index])  //Verifica se a frase que está sendo falada foi escrita por completa
        {
            if(index < senteces.Length - 1)  //enquanto ainda tem texto para ser lido
            {
                index++;
                speechText.text = "";  //limpa o campo de texto para a próxima fala
                StartCoroutine(TypeSentence());
            }
            else  //quando termina os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                senteces = null;  //Zera as falas
                isShowing = false; 
            }
        }
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
