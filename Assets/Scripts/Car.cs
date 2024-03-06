using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _rbCar;
    public float rotationSpeed = 30f;
    
    void Awake()
    {
        _rbCar = GetComponent<Rigidbody>();
    }
    void Update () {
        

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);
    }
    
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        _rbCar.MovePosition(transform.position + transform.forward * v);
    }

    
}
