using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{

    public float speed;  //cria uma variável pública para a velocidade do personagem
    public float runSpeed;  //seta a velocidade de corrida do player

    private Rigidbody2D rig; //manipular física

    private float initialSpeed;  //set a velocidade inicial do player
    private bool _isRunning;  //determina se o personagem está correndo
    private bool _isRolling;  //determina se o personagem está esquivando
    private bool _isCutting;  //determina se o personagem está cortando a árvore
    private bool _isDigging;  //determina se o personagem está cavando
    private bool _isWatering;
    private Vector2 _direction; //direção que o personagem está se movendo

    private int handlingObj;  //determina qual o objeto o jogador tem em mãos - começa com o valor de 0, logo, o jogador começa sem objetos em mãos

    public Vector2 direction //para deixar a variável pública para acesso em outros códigos
    {
        get { return _direction; }
        set { _direction = value; }
    }

     public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

     public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  //quando o jogo começa, a função pega dentro do objeto seu Rigidbody para poder aplicar física
        initialSpeed = speed;
    }

    private void Update() //inputos e/ou lógicas sem física
    {   
        if(Input.GetKeyDown(KeyCode.Alpha1))  //se o jogador clicar no número 1, determinando objeito fica em mãos
        {
            handlingObj = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))  //se o jogador clicar no número 2, determinando objeito fica em mãos
        {
            handlingObj = 1;
        }


        OnInput();

        OnRun();
        OnRoll();
        OnCut();
        OnDig();
    }

    private void FixedUpdate() //trabalha com físicas
    {
        OnMove();
    }

    #region Movement  
    // region serve para organiar um blocko de código

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //determina o input pressionado pelo jogador
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);  //faz o personagem andar na direção imposta pelo input
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCut()
    {
        if(handlingObj == 0)  //se o objeto em mãos for o primeiro, ação de cortar fica liberada
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if(handlingObj == 1)  //se o objeto em mãos for o segundo, ação de cavar fica liberada
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    #endregion
}
