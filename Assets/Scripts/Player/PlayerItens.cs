using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;  //Referencia a quantidade de madeiras coletadas pelo jogador

    public int TotalWood  //Encapsulamento para permitir que a variável totalWood seja acessada por outros scripts
    {
        get { return totalWood; }
        set { totalWood = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
