using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] _balls;
    [SerializeField] private Transform _ballParent;

    private int _randIndex;
    private bool _isHad;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        HasBall();
    }

    public void SpawnNewBall()
    {
        _randIndex = Random.Range(0, _balls.Length);
        Instantiate(_balls[_randIndex], _ballParent);
        _isHad = false;
    }

    public void HasBall()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("”ò‚Î‚µ‚½‚æ");
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("balls"))
                {
                    hit.collider.transform.position = Input.mousePosition;
                    Debug.Log("‚Æ‚Á‚½‚æ");
                }
            }
            _isHad = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("balls"))
        {
            SpawnNewBall();
        }
    }
}
