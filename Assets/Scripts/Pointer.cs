using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    /*
     * 
     * Class for bot target point
     * 
    */
    private IDamagable targerBot;
    public Transform FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 200, 1 << gameObject.layer);
        List<Collider> listColliders = new List<Collider>(colliders);
        listColliders.Remove(gameObject.GetComponent<Collider>());
        if (listColliders.Count > 0)
        {
            var index = Random.Range(0, listColliders.Count);
            var enemyTransform = listColliders[index].transform;
            targerBot = enemyTransform.gameObject.GetComponent<Bot>();
            return enemyTransform;
        }
        else return null;        
    }
    public IDamagable GetBot()
    {
        return targerBot;
    }
}
