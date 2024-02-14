using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;  //Referencia a quantidade de madeiras coletadas pelo jogador
    [SerializeField] private int currentWater;
    private int waterLimit = 50;

    public int TotalWood  //Encapsulamento para permitir que a variável totalWood seja acessada por outros scripts
    {
        get { return totalWood; }
        set { totalWood = value; }
    }

    public int TotalWater  //Encapsulamento para permitir que a variável totalWood seja acessada por outros scripts
    {
        get { return currentWater; }
        set { currentWater = value; }
    }

    public void WaterLimit(int water)
    {
        if(currentWater < waterLimit)
        {
            currentWater += water;
        }
        
    }
}
