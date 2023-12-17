using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;  
    private Animator anim;  

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();  //chama o código do player para poder acessar informações públicas
        anim = GetComponent<Animator>();  //chama o animator para poder acessar os parâmetros de transição

    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }


    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)  //caso o jogador aperte input de movimento, há mudança na animação do jogador de idle para walk
        {
            if(player.isRolling)  //checa se é true => pode ser subistituido por player.isRolling == true
            {
                anim.SetTrigger("isRoll"); 
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
        
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}
