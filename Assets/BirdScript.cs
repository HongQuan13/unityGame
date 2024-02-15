using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    // public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    float speed = 5f;
    FaceDetector faceDetector;
 
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));

    }
 
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        // float norm = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);
       
        if (birdIsAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, faceDetector.faceY, transform.position.z), step);
        }
        // Debug.Log("face detected:" +  new Vector3(transform.position.x, faceDetector.faceY, transform.position.z));
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}