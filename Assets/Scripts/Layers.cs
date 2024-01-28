using UnityEngine;

public static class Layers
{
    public static readonly LayerMask NPCLayerMask = LayerMask.GetMask("NPC");
    public static readonly LayerMask CollectableLayerMask = LayerMask.GetMask("Collectable");
}