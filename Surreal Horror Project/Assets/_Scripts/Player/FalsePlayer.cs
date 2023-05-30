using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalsePlayer : MonoBehaviour
{
    #region
    public static FalsePlayer instance
    {
        get
        {
            return _instance;
        }
    }
    public static FalsePlayer _instance;
    private void Awake()
    {
        _instance = this;
    }
    #endregion
}
