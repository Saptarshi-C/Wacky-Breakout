using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject standardBlockPrefab;

    [SerializeField]
    GameObject bonusBlockPrefab;

    [SerializeField]
    GameObject effectBlockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempBlock = Instantiate(effectBlockPrefab);
        float blockWidth = tempBlock.GetComponent<BoxCollider2D>().size.x;
        float blockHeight = tempBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tempBlock);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int numblocks = (int)(screenWidth / blockWidth);
        float baseY = ScreenUtils.ScreenTop * 4 / 5 - blockHeight;
        float leftBlockOffset = ScreenUtils.ScreenLeft + blockWidth / 2 + (screenWidth - numblocks * blockWidth) / 2;
        Vector2 blockLocation = new Vector2(leftBlockOffset, baseY);

        for(int i=0; i < 3; i++)
        {
            for(int j=0; j < numblocks; j++)
            {
                PlaceBlock(blockLocation);
                blockLocation.x += blockWidth;
            }
            blockLocation.y -= blockHeight;
            blockLocation.x = leftBlockOffset;
        }

    }

    void PlaceBlock(Vector2 blockLocation)
    {
        float randomPercent = Random.value * 100f;

        if (randomPercent < ConfigurationUtils.StandardBlockProb)
        {
            Instantiate(standardBlockPrefab, blockLocation, Quaternion.identity);
        }
        else if (randomPercent < ConfigurationUtils.StandardBlockProb + ConfigurationUtils.BonusBlockProb)
        {
            Instantiate(bonusBlockPrefab, blockLocation, Quaternion.identity);
        }
        else
        {
            GameObject effectBlock = Instantiate(effectBlockPrefab, blockLocation, Quaternion.identity);
            EffectBlock effectBlockScript = effectBlock.GetComponent<EffectBlock>();

            float freezerThreshold = ConfigurationUtils.StandardBlockProb + ConfigurationUtils.BonusBlockProb + ConfigurationUtils.FreezerBlockProb;
            if (randomPercent < freezerThreshold)
            {
                effectBlockScript.EffectName = EffectName.Freezer;
            }
            else
            {
                effectBlockScript.EffectName = EffectName.Speedup;
            }
        }
    }
}
