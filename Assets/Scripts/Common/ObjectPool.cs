using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject prefab;
    public int size;
    public bool isGrowable;

    List<GameObject> objects = new List<GameObject>();

    public void Init() {
        if (size <= 0) return;
        for (int i = 0; i < size; i++) {
            objects.Add(Instantiate(prefab, transform));
            objects[objects.Count - 1].SetActive(false);
        }
    }

    public void Init(GameObject prefab, int size) {
        this.prefab = prefab;
        this.size = size;
        Init();
    }

    public GameObject Get() {
        for (int i = 0; i < objects.Count; i++) {
            if (!objects[i].activeInHierarchy) {
                objects[i].SetActive(true);
                return objects[i];
            }
        }

        if (size < objects.Count || isGrowable) {
            objects.Add(Instantiate(prefab, transform));
            return objects[objects.Count - 1];
        }

        return null;
    }
}