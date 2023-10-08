using UnityEngine;

public class BonusMover : MonoBehaviour
{
    [SerializeField] private float movingSpeed;

    private void FixedUpdate()
    {
        transform.Translate(-movingSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
