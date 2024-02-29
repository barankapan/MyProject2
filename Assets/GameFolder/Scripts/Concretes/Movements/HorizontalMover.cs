using MyProject2.Abstracts.Controllers;
using MyProject2.Abstracts.Movements;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Movements {
    public class HorizontalMover : IMover 

    {
       IEntityController _entityController;
      
        

        public HorizontalMover(IEntityController entityController)
        {
            _entityController= entityController;
            

        }
        public void FixedTick(float horizontal)
        {
            if (horizontal == 0f) return;
            
             _entityController.transform.Translate(translation:Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);
             float xBoundary = Mathf.Clamp(value:_entityController.transform.position.x,min:-_entityController.MoveBoundary,max:_entityController.MoveBoundary);
             
           

             _entityController.transform.position = new Vector3(xBoundary,_entityController.transform.position.y,z:15f);
            
            
            
        }
    }

}

