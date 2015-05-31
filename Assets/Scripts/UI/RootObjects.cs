using UnityEngine;
using System.Collections;

public class RootObjects : MonoBehaviour {
    void Start()
    {
        UIScreenHandler.Instance.RegisterRootObject(this);
    }
}
