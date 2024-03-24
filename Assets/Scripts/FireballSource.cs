using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public float targetInSkyDistance;
    public Transform targetPoint;
    public Camera cameraLink;

    void Update()
    {
        FireballSourceUpdate();
    }

    private void FireballSourceUpdate()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.6f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(targetPoint.position);
    }
}
