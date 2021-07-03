using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }
    private void Update()
    {
        var newScale = healthBar.transform.localScale;
        newScale.x = Mathf.Lerp(newScale.x, _health.GetHealthPercent(), 0.3f);
        healthBar.transform.localScale = newScale;        
    }
}
