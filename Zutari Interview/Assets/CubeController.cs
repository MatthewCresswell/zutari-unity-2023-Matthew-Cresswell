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
        
        if(Input.GetKey(KeyCode.W))
        {
            cubeColor = new Color(255f, 0f, 0f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.A))
        {
            cubeColor = new Color(0f, 81f, 255f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.S))
        {
            cubeColor = new Color(191f, 80f, 0f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
        if(Input.GetKey(KeyCode.D))
        {
            cubeColor = new Color(192f, 0f, 255f, 0f);
            myRenderer.material.color = cubeColor;
            cubeMat = myRenderer.material;
            trail.material = cubeMat;
        }
    }

    public void ChangeSpeed()
    {
        if(Input.GetKey(KeyCode.J))
        {
            speed -= 0.025f;
        }
        if(Input.GetKey(KeyCode.K))
        {
            speed += 0.025f;
        }
        int moveSpeed = (int)speed;
        moveSpeedText.text = "Speed: " + moveSpeed.ToString() + "\n  -J | K+";
    }

    public void IncreaseSpeed()
    {
        speed *= 1.25f;
    }
    public void DecreaseSpeed()
    {
        speed *= 0.9f;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        Vector3 velocity = speed * input;
        Vector3 tempPosition = transform.localPosition + velocity * Time.deltaTime;
        if(screenBound.IsOutOfBounds(tempPosition))
        {
            Vector2 newPosition = screenBound.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }
        ChangeSpeed();
        ChangeCubeColour();
    }
}