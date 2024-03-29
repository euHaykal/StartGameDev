using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    [SerializeField] private ParticleSystem leafs;  //Referencia o sistema de partícula das folhas

    [SerializeField] private bool isCut;

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();  //Aciona o sistema de Partículas quando o player hita a árvore

        if(treeHealth <= 0)
        {
            //cria o toco e instancia os drops (madeira)
            for(int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f),Random.Range(-0.5f, 0.5f),0f), transform.rotation);
            }
            anim.SetTrigger("cut");

            isCut = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
