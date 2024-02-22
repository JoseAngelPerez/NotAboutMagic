using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    private bool isActive;

    [SerializeField] private GameObject WallToSwitch;

    [SerializeField] private float timeToRestart= 15f;

    public UnityEvent SwitchActive, SwitchReady;
    void Start()
    {
        isActive = false;
        WallToSwitch.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player" && isActive == false)
        {
            isActive = true;
            WallToSwitch.SetActive(true);
            SwitchActive?.Invoke();
            StartCoroutine(RestartSwitch());
        }
    }

    private IEnumerator RestartSwitch()
    {
        yield return new WaitForSeconds(timeToRestart);
        SwitchReady?.Invoke();
        isActive = false;
        WallToSwitch.SetActive(false);
    }


}
