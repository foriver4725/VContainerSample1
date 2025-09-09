using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

internal sealed class Controller : ITickable, IDisposable
{
    private CharacterTransforms characterTransforms;
    private CharacterStatuses characterStatuses;

    [Inject]
    internal void Construct(CharacterTransforms transforms, CharacterStatuses statuses)
    {
        characterTransforms = transforms;
        characterStatuses = statuses;
    }

    public void Tick()
    {
        if (characterTransforms.playerTransform == null) return;
        if (characterTransforms.enemyTransform == null) return;

        Vector3 p = characterTransforms.playerTransform.position;
        Vector3 e = characterTransforms.enemyTransform.position;
        p.y = 0;
        e.y = 0;

        Vector3 e2p = (p - e).normalized;
        Vector3 eMove = e2p * (characterStatuses.enemySpeed * Time.deltaTime);
        Vector3 pMove = (Quaternion.AngleAxis(90, Vector3.up) * e2p) * (characterStatuses.playerSpeed * Time.deltaTime);

        characterTransforms.enemyTransform.position += eMove;
        characterTransforms.playerTransform.position += pMove;
    }

    public void Dispose()
    {
        characterTransforms = null;
        characterStatuses = null;

        Debug.Log("Controller.Dispose()");
    }
}
