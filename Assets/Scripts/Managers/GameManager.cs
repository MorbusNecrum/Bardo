using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject zombie;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnZombie()
    {
        GameObject z = Instantiate(zombie);
        z.GetComponent<LifeController>().OnDeath.AddListener(SpawnZombie);
    }
}
