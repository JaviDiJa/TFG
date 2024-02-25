using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float speedRunning;
    //[SerializeField] private float speedCrouching;
    //[SerializeField] private float speedJumping;

    [SerializeField] private float range = 999f;

    private Vector3 direccion;
    private Vector2 input;

    private CharacterController characterController;
    //private Animator animator;

    public bool isRunning;
    public bool isCrouching;
    public bool isAiming;
    public bool isShooting;
    public bool isJumping;
    public bool isReloading;

    public CinemachineFreeLook freeLookCamera;

    //public Disparador disparador;

    //public HealthSliderManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        direccion = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();

        //healthManager = GetComponent<HealthSliderManager>();

        isRunning = false;
        isCrouching = false;
        isAiming = false;
        isJumping = false;
        isShooting = false;
    }

    private void FixedUpdate()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * 6f * Time.fixedDeltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (healthManager.vidaActual > 0)
        {
            // MOVIMIENTO
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Correr();
            }
            else
            {
                Moverse();
            }

            //    // FUNCIONAMIENTO AGACHARSE

            //    if (Input.GetKeyDown(KeyCode.LeftControl))
            //    {
            //        isCrouching = true;
            //        animator.SetBool("isCrouching", true);
            //        isRunning = false;
            //    }

            //    if (Input.GetKeyUp(KeyCode.LeftControl))
            //    {
            //        isCrouching = false;
            //        animator.SetBool("isCrouching", false);
            //    }

            //    if (isCrouching)
            //    {
            //        characterController.Move(direccion * speedCrouching * Time.deltaTime);

            //        playerVirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset = new Vector3(0.4f, 1f);
            //    }
            //    else
            //    {
            //        characterController.Move(direccion * speed * Time.deltaTime);
            //        playerVirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset = new Vector3(0.4f, 1.3f);
            //    }

            //    // FUNCIONAMIENTO APUNTADO

            //    if (Input.GetKeyDown(KeyCode.Mouse1) && disparador.currentAmmo > 0 && !isRunning)
            //    {
            //        isAiming = true;
            //        isRunning = false;
            //        animator.SetBool("isAiming", true);
            //    }

            //    if (Input.GetKeyUp(KeyCode.Mouse1))
            //    {
            //        isAiming = false;
            //        animator.SetBool("isAiming", false);
            //    }

            //    if (isAiming)
            //    {
            //        speed = 1.2f;
            //    }

            //    if (isAiming && isCrouching)
            //    {
            //        animator.SetBool("isCrouching", true);
            //        animator.SetBool("isAiming", true);
            //    }
            //    else
            //    {
            //        characterController.Move(direccion * speed * Time.deltaTime);
            //    }

            //    //FUNCION DISPARO

            //    if (Input.GetButton("Fire1") && !isReloading && disparador.currentAmmo > 0 && !isRunning)
            //    {
            //        isShooting = true;
            //        animator.SetBool("isShooting", true);
            //    }

            //    if (Input.GetButtonUp("Fire1"))
            //    {
            //        animator.SetBool("isShooting", false);
            //    }
            //    else
            //    {
            //        isShooting = false;
            //        speed = 1.8f;
            //    }

            //    // FUNCION RECARGAR

            //    if (Input.GetKey(KeyCode.R) && disparador.currentAmmo < disparador.maxAmmo && !isRunning && disparador.totalAmmo > 0 || disparador.currentAmmo == 0 && disparador.totalAmmo > 0)
            //    {
            //        StartCoroutine(Recargar());

            //        //isReloading = true;
            //        //speed = 0f;

            //        ////animator.SetBool("isAiming", false);
            //        ////animator.SetBool("isShooting", false);

            //        //animator.SetBool("isReloading", true);
            //        //Invoke("RecargaLista", 2f);
            //    }

            //    if (isReloading || isReloading && isAiming)
            //    {
            //        speed = 0f;
            //    }

            //    //else
            //    //{
            //    //    animator.SetBool("isReloading", false);
            //    //}

            //    ////if (Input.GetKeyUp(KeyCode.R) || disparador.currentAmmo == disparador.maxAmmo)
            //    ////{
            //    ////    isReloading = false;
            //    ////    animator.SetBool("isReloading", false);
            //    ////}

            //    //if(disparador.currentAmmo == disparador.maxAmmo)
            //    //{
            //    //    animator.SetBool("isReloading", false);
            //    //}

            //}

            //else
            //{
            //    animator.SetBool("isDead", true);
            //}
        }

        void Moverse()
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            direccion = (transform.forward * input.y + transform.right * input.x);

            if (direccion.magnitude > 0.75)
            {
                direccion.Normalize();
            }

            //animator.SetFloat("InputX", input.x);
            //animator.SetFloat("InputX", input.x);
            //animator.SetFloat("InputY", input.y);

            characterController.Move(direccion * speed * Time.deltaTime);

            isRunning = false;
            //animator.SetBool("isRunning", false);

            isCrouching = false;
            //animator.SetBool("IsCrouching", false);

            isAiming = false;
            //animator.SetBool("isAiming", false);
        }

        void Correr()
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            isRunning = true;
            isCrouching = false;
            isAiming = false;
            //animator.SetBool("isRunning", true);

            if (direccion.magnitude > 0.75)
            {
                direccion.Normalize();
            }

            direccion = (transform.forward * input.y + transform.right * input.x);
            characterController.Move(direccion * speedRunning * Time.deltaTime);
        }

        //IEnumerator Recargar()
        //{
        //    isReloading = true;
        //    animator.SetBool("isShooting", false);
        //    animator.SetBool("isReloading", true);
        //    speed = 0f;
        //    Debug.Log("Recargando");

        //    yield return new WaitForSeconds(2f);

        //    isReloading = false;
        //    animator.SetBool("isReloading", false);
        //    speed = 1.8f;
        //}
    }
}
