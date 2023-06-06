using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{
    [Range(1f,100f)]
    public float SensibilityHorizontale, SensibilityVerticale;
    public Transform RotatedHorizontale;
    private Camera pv_Camera;

    void Awake()
    {
        pv_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.lockState = CursorLockMode.Locked;
        RotateHorizontale();
        RotateVerticale();

    }

    private void RotateHorizontale()
    {

        float mouseposX = Input.GetAxis("Mouse X");
        Vector3 rotate = RotatedHorizontale.eulerAngles;
        rotate = new Vector3(rotate.x, rotate.y + (mouseposX * SensibilityHorizontale), rotate.z);
        RotatedHorizontale.eulerAngles = rotate;
        
    }

    private void RotateVerticale()
    {

        float mouseposY = Input.GetAxis("Mouse Y");
        Vector3 rotate = pv_Camera.transform.eulerAngles;
        rotate = new Vector3(ClampAngle(rotate.x - (mouseposY * SensibilityVerticale),-90,90), rotate.y, rotate.z);
        pv_Camera.transform.eulerAngles = rotate;

    }

    private float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f)
        {
            angle = 360f + angle;
        }
        if (angle > 180f)
        {
            return Mathf.Max(angle, 360f + from);
        }
        return Mathf.Min(angle, to);
    }

}
