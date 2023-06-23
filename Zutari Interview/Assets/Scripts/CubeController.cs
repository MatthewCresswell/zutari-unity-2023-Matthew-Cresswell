using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeController : MonoBehaviour
{
    public float speed = 2f;
    public Transform cube;
    public ScreenBoundary screenBound;
    [SerializeField] private Material cubeMat;
    public TrailRenderer trail;
    public Color cubeColor;
    public Renderer myRenderer;
    public TMP_Text moveSpeedText;

    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        trail = gameObject.GetComponent<TrailRenderer>();
    }
    
    private void ChangeCubeColour()
    {
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //if W is pressed change colour to Red
        {
            cubeColor = new Color(255f, 0f, 0f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //if A is pressed change colour to Blue
        {
            cubeColor = new Color(0f, 81f, 255f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //if S is pressed change colour to Yellow
        {
            cubeColor = new Color(191f, 80f, 0f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //if D is pressed change colour to Pink
        {
            cubeColor = new Color(192f, 0f, 255f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
    }

    public void ChangeSpeed() // adjust speed with J & K keys
    {
        if(Input.GetKey(KeyCode.J))
        {
            speed *= 0.99f;
        }
        if(Input.GetKey(KeyCode.K))
        {
            speed *= 1.01f;
        }
        int moveSpeed = (int)speed;
        moveSpeedText.text = "Speed: " + moveSpeed.ToString() + "\n  -J | K+";
    }

    public void IncreaseSpeed() //increase speed button
    {
        speed *= 1.25f;
    }
    public void DecreaseSpeed() //decrease speed button
    {
        speed *= 0.9f;
    }

    void Update()
    {
        //allows cube to move along x & y access
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        Vector3 velocity = speed * input;
        Vector3 tempPosition = transform.localPosition + velocity * Time.deltaTime;
        if(screenBound.IsOutOfBounds(tempPosition))//check if the cube is out of screen bounds, if true recalculates position
        {
            Vector2 newPosition = screenBound.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else//if false keep cube in current position
        {
            transform.position = tempPosition;
        }
        ChangeSpeed();
        ChangeCubeColour();
    }
}