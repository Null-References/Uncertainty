using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private NonRepeatableTimer _timer;
    private void Update()
    {
        //raycast
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void DeSpawn()
    {

    }
}