using UnityEngine;
 
public class HealthBar : MonoBehaviour
{
    public Transform enemy;
    public float f = -7f;
    void Update()
    {
        if(enemy == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = enemy.position + transform.forward * f;
        }
    }
}