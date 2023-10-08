using UnityEngine;

public class EnemyMover : MonoBehaviour
{
   [SerializeField] private float movingSpeed;
   private GameObject _enemiesParent;

   private void Awake()
   {
       _enemiesParent = GameObject.Find("Enemies");
       transform.SetParent(_enemiesParent.transform);
   }

   private void FixedUpdate()
   {
       transform.Translate(0.0f, movingSpeed * Time.deltaTime, 0.0f);
   }
}
