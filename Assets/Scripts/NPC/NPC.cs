using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;  //Referencia a velocidade do movimento do NPC

    private int index;  //Referencia contagem para determinar em que "path" o NPC está

    public List<Transform> paths = new List<Transform>();  //Referencia os "paths"
    

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);  //Determina a direção que o personagem deve seguir

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)  //Determina se o NPC chegou no "path" -> posição npc - posição do path até dar zero
        {
            if(index < paths.Count - 1)  //checa se o index é menor que o tamanho da lista
            {

            }
        }
    }
}
