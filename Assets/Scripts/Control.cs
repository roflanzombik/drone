using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control : MonoBehaviour
{
    public float _moveSpeed = 3;    
    private Rigidbody _rb;
    private bool _isGrounded = false;

    public void Awake(){
         _rb = gameObject.GetComponent<Rigidbody>();
    }    
    public void Update(){  

        float _HorizontalInput = Input.GetAxis("Horizontal");
        float _VerticalInput = Input.GetAxis("Vertical");
        float _fly = Input.GetAxis("fly");
        
        transform.Rotate(new Vector3(Input.GetAxis("pitch"), Input.GetAxis("yaw"), Input.GetAxis("roll")));

       
        // new Vector3(_HorizontalInput, 0.0f, _VerticalInput );

        transform.Translate(new Vector3(_HorizontalInput, _fly, _VerticalInput) * _moveSpeed * Time.deltaTime);

        if ( !_isGrounded && !(Input.GetKey("space")) & !(Input.GetKey("w")) & !(Input.GetKey("s")) & !(Input.GetKey("a")) & !(Input.GetKey("d"))){
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime * 0.3f);
        }
    }

    private void OnTriggerEnter(Collider other){
			if (other.tag == "ground") {
					_isGrounded = true;

				}
			}

	private void OnTriggerExit(Collider other){
		if (other.tag == "ground"){
			_isGrounded = false;

		}
	}
    
}
