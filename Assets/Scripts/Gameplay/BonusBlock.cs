using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        BlockPoints = ConfigurationUtils.BonusBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
