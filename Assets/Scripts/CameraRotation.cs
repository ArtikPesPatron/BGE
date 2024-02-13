using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Transform CameraAxisTrans;

    public float sensitivity;

    public float RotMult;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraAxisTrans.localEulerAngles = new Vector3(CameraAxisTrans.localEulerAngles.x + Time.deltaTime * RotMult * sensitivity * Input.GetAxis("Mouse Y") * -1, 0, 0);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotMult * Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}
