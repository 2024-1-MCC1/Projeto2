using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float velocity = 2.0f; // velocidade do personagem
    public float rotation = 500.0f; //valor da sensibilidade do mouse
    public float rotationVertical = 500.0f; // Nova vari�vel para a velocidade de rota��o vertical

    public float maxVerticalAngle = 30.0f; // Limite m�ximo de rota��o vertical
    public float minVerticalAngle = -30.0f; // Limite m�nimo de rota��o vertical

    private Animator anim;
    private Transform cameraTransform; // Refer�ncia para o transform da c�mera

    private float verticalRotation = 0.0f; // Rota��o vertical acumulada

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Prende o cursor na tela
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform; // Obt�m o transform da c�mera principal


        // Adiciona o listener para o evento de animação
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.time = 1.0f; // Ajuste o tempo para o final da animação
        animationEvent.functionName = "OnAnimationEnd";
        AnimationClip clip = anim.runtimeAnimatorController.animationClips[3]; // Altere para o índice correto da animação 3
        clip.AddEvent(animationEvent);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //da a movimentação do personagem na vertical e na horizontal
        float y = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X"); // Obt�m o movimento do mouse na horizontal

        float mouseY = Input.GetAxis("Mouse Y"); // Obt�m o movimento do mouse na vertical

        Vector3 dir = new Vector3(x, 0, y) * velocity;

        transform.Translate(dir * Time.deltaTime);
        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));

        // Acumula a rota��o vertical
        verticalRotation -= mouseY * rotationVertical * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Aplica a rota��o vertical acumulada � c�mera
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        //Anima��o andar W
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("transition", 1);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("transition", 0);
        }


        //Anima��o andar S
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("transition", 1);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("transition", 0);
        }

        //Animação andar A
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("transition", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("transition", 0);
        }

        //Animação andar D
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("transition", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("transition", 0);
        }

        //Anima��o Capoeira F
        if (Input.GetKey(KeyCode.F))
        {
            anim.SetInteger("transition", 2);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            anim.SetInteger("transition", 0);
        }

        //Anima��o Pegar E
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("transition", 3);
        }
    }

         // Função chamada no final da animação 3
        void OnAnimationEnd()
        {
        // Volta para a animação idle
        anim.SetInteger("transition", 0);
        }






}










