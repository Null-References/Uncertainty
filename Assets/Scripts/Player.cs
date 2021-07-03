using UnityEngine;

public class Player : MonoBehaviour
{
    public float xp;
    public void PlayerDeath()
    {
        gameObject.SetActive(false);
    }
}