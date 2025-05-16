using System;
using System.Linq;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private void Start()
    {
        var result = FindObjectsOfType<T>();
        if (result.Length == 0)
        {
            throw new Exception($"{typeof(T).Name}�̓V�[���ɑ��݂��܂���");
        }
        if (result.Length != 1)
        {
            result.ToList().ForEach(r => Debug.LogError(r.name));
            throw new Exception($"{typeof(T).Name}�̓V�[����2�ȏ㑶�݂��Ă��܂�");
        }
    }

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var result = FindObjectsOfType<T>();
                if (result.Length == 0)
                {
                    throw new Exception($"{typeof(T).Name}�̓V�[���ɑ��݂��܂���");
                }
                if (result.Length != 1)
                {
                    result.ToList().ForEach(r => Debug.LogError(r.name));
                    throw new Exception($"{typeof(T).Name}�̓V�[����2�ȏ㑶�݂��Ă��܂�");
                }
                _instance = result[0];
            }

            return _instance;
        }
    }
}
