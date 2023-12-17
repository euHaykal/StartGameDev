using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")] 
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]  //Cabeçalho, aparece como título de uma sessão de variáveis
    public GameObject actor;  //Referencia prefab de npc

    [Header("Dialogue")]
    public Sprite spaekerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences  //Atributos referentes ao npc
{
    public string actorName;
    public Sprite profile;
    public Languages sentece;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
}

#if UNITY_EDITOR  //Permitiu criar um botão de adicionar falas no editor
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor  
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();  //Permite modificar o Inspector

        DialogueSettings ds = (DialogueSettings)target;  //Declarou um objeto da classe DialogueSettings

        Languages l = new Languages();  //Declarou um objeto da classe Languages
        l.portuguese = ds.sentence;  //Essa linha implica que a sentença escrita sempre será adicionada no campo portuguese

        Sentences s = new Sentences();  
        s.profile = ds.spaekerSprite;  //Referencia sprite do diálogo
        s.sentece = l;

        if (GUILayout.Button("CreateDialogue"))  //Permite criar um botão funcional
        {
            if (ds.sentence != "")  //Caso o campo de tensença esteja preenchido ele cria um novo diálogo com as propriedades inseridas
            {
                ds.dialogues.Add(s);  //Adiciona a lista a fala digitada

                ds.spaekerSprite = null;  //Apaga a Spirte para o próximo diálogo criado
                ds.sentence = "";  //Limpa o campo de sentença para colocar a nova fala digitada
            }
        }
    }

}

#endif