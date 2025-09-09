using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

internal sealed class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private CharacterTransforms characterTransforms;
    [SerializeField] private CharacterStatuses characterStatuses;

    protected sealed override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(characterTransforms);
        builder.RegisterComponent(characterStatuses);

        builder.RegisterEntryPoint<Controller>(Lifetime.Singleton);
    }
}
