using UnityEngine;

public class Player : MonoBehaviour
{
    public void PlayerDeath()
    {
        gameObject.SetActive(false);
    }
}