using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour, IZone
{

    [SerializeField] private string id;
    public string Id => id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().EnterZone(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().LeftZone(this);
        }
    }
}
