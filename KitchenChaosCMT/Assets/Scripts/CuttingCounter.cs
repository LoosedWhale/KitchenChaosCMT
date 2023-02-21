using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;


    public override void Interact(Player player){
        if (!HasKitchenObject()) {
            // There is no KitchenObject on this counter
            if (player.HasKitchenObject()) {
                // Player is carrying a KitchenObject
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    // Player carry something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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

    public override void InteractAlternative(Player player) {
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
            // There is a KitchenObject on this counter AND it can be cut
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);


        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) {
                return cuttingRecipeSO.output;
            }
        }

        return null;
    }
}
