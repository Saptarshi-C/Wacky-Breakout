using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        BlockPoints = ConfigurationUtils.StandardBlockPoints;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
