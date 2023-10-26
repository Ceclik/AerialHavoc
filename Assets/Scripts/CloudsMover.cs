using UnityEngine;

public class CloudsMover : MonoBehaviour
{
    [SerializeField] private Transform[] farClouds;
    [SerializeField] private float farCloudsSpeed;

    [SerializeField] private Transform[] middleClouds;
    
    [SerializeField] private Transform[] closeClouds;

    private void FixedUpdate()
    {
        foreach (Transform clouds in farClouds)
        {
            clouds.Translate(-farCloudsSpeed * Time.deltaTime, 0.0f, 0.0f);
            if (clouds.position.x < -850.0f)
                clouds.position = new Vector3(900.0f, 0.0f, clouds.position.z);
        }
        foreach (Transform clouds in middleClouds)
        {
            clouds.Translate(-farCloudsSpeed * Time.deltaTime, 0.0f, 0.0f);
            if (clouds.position.x < -970.0f)
                clouds.position = new Vector3(1000.0f, 0.0f, clouds.position.z);
        }
        foreach (Transform clouds in closeClouds)
        {
            clouds.Translate(-farCloudsSpeed * Time.deltaTime, 0.0f, 0.0f);
            if (clouds.position.x < -840.0f)
                clouds.position = new Vector3(1025.0f, 0.0f, clouds.position.z);
        }
    }
}
