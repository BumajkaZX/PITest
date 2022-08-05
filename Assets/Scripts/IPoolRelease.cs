using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolRelease 
{
    public void PoolRelease(GameObject objectToRelease);
}
