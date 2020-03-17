using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*This class will contain the behavior for the enemies seen within the game.
 * "Duckman" ai Critter(s) will patrol the maze
 * "Garfield" ai critter will have exclusive behavior as it is the end "boss" AI
 */

namespace ACFramework
{
    class AIBehavior
    {
        cCritter3Dcharacter controlledcritter;
        //-----------------------------------AI Constructor------------------------------\\
        public AIBehavior(cCritter3Dcharacter aiCritter)
        {
            controlledcritter = aiCritter;
            
            aiPatrol(controlledcritter);
        }

        public void aiPatrol(cCritter3Dcharacter duckman)
        {

        }
    }
}
