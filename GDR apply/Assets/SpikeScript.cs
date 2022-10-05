using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject UI;
    private IEnumerator coroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Spike")
        {
            animator.SetTrigger("Die");
            coroutine = WaitAndDestroy(1.5f);
            StartCoroutine(coroutine);
        }
        IEnumerator WaitAndDestroy(float waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                Destroy(gameObject);
                UI.SetActive(true);
            }
        }
    }

}
