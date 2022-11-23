using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5;
    [SerializeField] private float SteerSpeed = 180;
    [SerializeField] private float BodySpeed = 5;
    [SerializeField] private int Gap = 10;
    
    [SerializeField] private GameObject BodyPrefab;
    
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    
    void Start() {
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }
    
    void Update() {
        
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        
        float steerDirection = Input.GetAxis("Horizontal");
        float upDirection = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * -upDirection * SteerSpeed * Time.deltaTime);
        
        PositionsHistory.Insert(0, transform.position);
        
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];
            
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            
            body.transform.LookAt(point);

            index++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            GrowSnake();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Cherry"))
        {
            GrowSnake();
            GrowSnake();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Pepper"))
        {
            GrowSnake();
            GrowSnake();
            GrowSnake();
            Destroy(other.gameObject);
        }
    }

    private void GrowSnake() {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
}
