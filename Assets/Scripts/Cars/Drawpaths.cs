using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawpaths : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }
    // Start is called before the first frame update
    public PathTypes pathTypes;
    public int movedir = 1;
    public int moveingTo = 0;
    public Transform[] pathElements;

    public void OnDrawGizmos()
    {
        if(pathElements == null || pathElements.Length < 2)
        {
            return;
        }

        for (int i = 1; i < pathElements.Length; i++)
        {
            Gizmos.DrawLine(pathElements[i - 1].position, pathElements[i].position);
        }

        if (pathTypes== PathTypes.loop)
        {
            Gizmos.DrawLine(pathElements[0].position, pathElements[pathElements.Length - 1].position);  
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (pathElements == null || pathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return pathElements[moveingTo];

            if (pathElements.Length == 1)
            {
                continue;
            }
            if (pathTypes == PathTypes.linear)
            {
                if (moveingTo<=0)
                {
                    movedir = 1;
                }
                else if (moveingTo >= pathElements.Length - 1)
                {
                    movedir = -1;
                }
            }
            moveingTo += moveingTo + movedir;

            if (pathTypes ==PathTypes.loop)
            {
                if (moveingTo >= pathElements.Length)
                {
                    moveingTo = 0;
                }
                if (moveingTo<0)
                {
                    moveingTo = pathElements.Length - 1;
                }
            }
        }
    }
}
