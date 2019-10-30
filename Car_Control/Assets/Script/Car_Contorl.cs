using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Contorl : MonoBehaviour
{
    [Header("汽車速度"),Range(0,100)]
    public float speed=10;
    [Header("汽車轉彎速度"), Range(0, 100)]
    public float speed_turn=10;
    [Header("汽車擋位"), Range(0, 5)]
    public float shift=1;
    [Header("汽車煞車")]
    public bool stop;
    [Header("汽車品牌")]
    public string car_Brand;
    [Header("汽車顏色")]
    public Renderer color;
    [Header("汽車變形元件")]
    public Transform car_object;
    Rigidbody car;

    private void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
           // car.velocity = car.transform.right * -10;
           // speed = car.velocity.magnitude;
            car.AddForce(car.transform.right*-speed, ForceMode.Force);
            print('w');
        }
        else if (Input.GetKey(KeyCode.S))
        {
            /*car.velocity = car.transform.right * 10;
            speed = car.velocity.magnitude;*/
            car.AddForce(car.transform.right * speed, ForceMode.Acceleration);
            print('s');
        }
         if (Input.GetKey(KeyCode.A))
        {
            car.angularVelocity = new Vector3(0, -speed_turn, 0);
            print('a');
        }
        else if (Input.GetKey(KeyCode.D))
        {
            car.angularVelocity = new Vector3(0, speed_turn, 0);
            print('d');
        }
        if (Input.GetKeyDown(KeyCode.Q)&&shift<2)
        {
            shift++;
            print('q');

        }
        else if (Input.GetKeyDown(KeyCode.E)&&shift>0)
        {
            shift--;
            print('e');
        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            stop = true;
            car.drag = 10;
            print("Space_down");

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            stop = false;
            car.drag = 0;
            print("Space_Up");

        }

    }

}
