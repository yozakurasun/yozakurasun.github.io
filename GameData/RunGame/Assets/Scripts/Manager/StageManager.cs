using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    private int _spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * -_scrollSpeed, 0, 0);

        if (this.transform.position.x <= -20f && _spawnIndex == 0)
            {
                GameManager.Instance.SpawnRandamStage();
                _spawnIndex++;
                Destroy(gameObject);
            }
    }
}
