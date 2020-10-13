using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    private Rigidbody myBody;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float chanceForCollectable;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    private void Start()
    {
        if(Random.value < chanceForCollectable)
        {
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(coin, temp, Quaternion.identity);
        }
    }

    IEnumerator TriggerFallingDown()
    {
        yield return new WaitForSeconds(0.3f);
        myBody.isKinematic = false;
        audioSource.Play();
        StartCoroutine(TurnOffGameObject());
       // yield return new WaitForSeconds(5f);
       // Destroy(gameObject);
    }

    IEnumerator TurnOffGameObject()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Ball")
        {
            StartCoroutine(TriggerFallingDown());
        }
    }
}
