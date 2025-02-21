using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ControleSousMarin : MonoBehaviour
{

    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;
    private Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Debug.Log(directionInput);
    }

    void OnPromener(InputValue directionBase){
        Vector2 direction = directionBase.Get<Vector2>() ;
        directionInput = new Vector3(0f, direction.x, direction.y)* _vitessePromenade;
        
    }

    void FixedUpdate(){
     
       _rb.AddForce(directionInput, ForceMode.VelocityChange);
        _animator.SetFloat("Deplacement", _rb.velocity.magnitude);
        
    }
}
