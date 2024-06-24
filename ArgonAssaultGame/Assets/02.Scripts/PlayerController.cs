using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;
    [SerializeField] GameObject[] lasers;

    [SerializeField] float PositionPitchFactor = -2f;
    [SerializeField] float ControlPitchFactor = -10f;
    [SerializeField] float PositionYawFactor = 2f;
    [SerializeField] float PositionRollFactor = -20f;

    ParticleSystem.EmissionModule emissionModule;

    float xAxis;
    float yAxis;


    void Update()
    {
        ProcessPosition();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessPosition()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        float xOffset = xAxis * Time.deltaTime * controlSpeed;
        float xPos = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(xPos, -xRange, xRange);

        float yOffset = yAxis * Time.deltaTime * controlSpeed;
        float yPos = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(yPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchPosition = transform.localPosition.y * PositionPitchFactor;
        float pitchControl = yAxis * ControlPitchFactor;

        float pitch = pitchPosition + pitchControl; //rotation.x
        float yaw = transform.localPosition.x * PositionYawFactor; //rotation.y
        float roll = xAxis * PositionRollFactor; //rotation.z

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if(Input.GetButton("Shooting"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }

    private void SetActiveLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
