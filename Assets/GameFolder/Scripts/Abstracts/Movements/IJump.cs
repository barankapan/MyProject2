using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Abstracts.Movements
{
    public interface IJump 
    {

        void FixedTick(float _jumpForce);
    }
}
