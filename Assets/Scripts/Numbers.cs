using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;

public class Numbers : MonoBehaviour
{
    private int number;
    private float duration = 2.0f;
    private float rotationAngle = 360f;

    void TransitionToPosition(Vector3[] position)
    {

        transform.DOPath(position, duration, PathType.Linear, PathMode.Full3D, 10, null).SetEase(Ease.InOutSine).OnComplete(SetGameActive);
        transform.DORotate(Vector3.forward * rotationAngle, duration, RotateMode.FastBeyond360);
    }

    void SetGameActive()
    {
        GameManager.instance.IsGameStarted = true;
    }
    public void MoveToPosition(Vector3 spawnPosition, Vector3 position)
    {
        Vector3[] path = { spawnPosition, position };
        TransitionToPosition(path);
    }
    public int GetNumber()
    {
        return number;
    }
    public void SetNumber(int number)
    {
        this.number = number;
    }
}
