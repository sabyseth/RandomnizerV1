using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public UnityEvent OnGunShoot;
    public float FireCoolDown;
    public bool Automatic;
    public float CurrentCoolDown;
    
    void Start()
    {
        CurrentCoolDown = FireCoolDown;
    }

    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCoolDown <= 0f){
                OnGunShoot?.Invoke();               
                CurrentCoolDown = FireCoolDown;
                }
            }
        }
        else{
            if (Input.GetMouseButton(0))
            {
                if (CurrentCoolDown <= 0f)
                {
                    OnGunShoot?.Invoke();
    
                    CurrentCoolDown = FireCoolDown;
                }
            }
        }
        CurrentCoolDown -= Time.deltaTime;
    }
}
