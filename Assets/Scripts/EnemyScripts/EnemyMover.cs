using UnityEngine;

public class EnemyMover : MonoBehaviour
{
   [SerializeField] private float movingSpeed;

   private void FixedUpdate()
   {
      transform.Translate(0.0f, movingSpeed * Time.deltaTime, 0.0f);
   }
}
