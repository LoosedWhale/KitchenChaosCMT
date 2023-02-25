using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no KitchenObject on this counter
            if (player.HasKitchenObject()) {
                // Player is carrying a KitchenObject
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player is not carrying a KitchenObject
            }
        } else {
            // There is a KitchenObject on this counter 
            if (player.HasKitchenObject()) {
                // Player is carrying a KitchenObject
            } else {
                // Player is not carrying a KitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

}
