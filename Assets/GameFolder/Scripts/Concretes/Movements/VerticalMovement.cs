using MyProject2.Abstracts.Controllers;
using MyProject2.Abstracts.Movements;
using MyProject2.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyProject2.Movements
{
    public class VerticalMovement : IMover
    {
        IEntityController _entityController;
        
        public VerticalMovement(IEntityController entityController)
        {
                _entityController= entityController;
                
        }
        public void FixedTick(float vertical = 1)

        {
            _entityController.transform.Translate(Vector3.back * vertical * _entityController.MoveSpeed * Time.deltaTime);

        }
    }
}

