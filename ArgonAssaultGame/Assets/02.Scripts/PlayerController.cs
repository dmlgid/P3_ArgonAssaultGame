using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        float xOffset = xAxis * Time.deltaTime * controlSpeed;
        float xPos = transform.localPosition.x + xOffset;

        float yOffset = yAxis * Time.deltaTime * controlSpeed;
        float yPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
