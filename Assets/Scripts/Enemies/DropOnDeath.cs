using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    private LifeController lifeController;
    private Factory dropsFactory;
    [SerializeField] private List<string> dropsIDs = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lifeController = GetComponent<LifeController>();
        lifeController.OnDeath.AddListener(Drop);
        dropsFactory = GameObject.Find("DropsFACTORY").GetComponent<Factory>();
    }

    private void Drop()
    {
        foreach (var drop in dropsIDs)
        {
            GameObject obj = dropsFactory.CreateGameObject(drop);
            obj.transform.position = transform.position;
        }
    }
}
