using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeV1
{
    /// <summary>
    /// Vector class to process the drone movement
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// VectorMovement perform functionality of moving done in vectors based on command provided 
        /// </summary>
        /// <param name="worldVectorArr">World vector values</param>
        /// <param name="droneVectorArr">Drone vector values</param>
        /// <param name="droneCommandList">Drone command values</param>
        /// <returns>True or False for drone movement successful or not</returns>
        public bool VectorMovement(List<string> worldVectorArr, List<string> droneVectorArr, List<DroneCmdViewModel> droneCommandList)
        {
            Console.WriteLine(string.Concat("Drone starts at: (", droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2], ")"));
            //cmdVector string hold from position of drone and droneVector string hold to position of drone
            string cmdVector = ""; string droneVector = "";

            //Variables to hold world vector
            int wx = Convert.ToInt32(worldVectorArr[0]);
            int wy = Convert.ToInt32(worldVectorArr[1]);
            int wz = Convert.ToInt32(worldVectorArr[2]);

            //Variables to hold original drone starting vector
            int orgDx = Convert.ToInt32(droneVectorArr[0]);
            int orgDy = Convert.ToInt32(droneVectorArr[1]);
            int orgDz = Convert.ToInt32(droneVectorArr[2]);

            //Variables to hold changing drone vector
            int dx = Convert.ToInt32(droneVectorArr[0]);
            int dy = Convert.ToInt32(droneVectorArr[1]);
            int dz = Convert.ToInt32(droneVectorArr[2]);

            //Ordering of drone commands in ascending order
            droneCommandList = droneCommandList.OrderBy(a => a.OrderNo).ToList(); 

            //Execution of drone commands by direction and handle the crash test.
            foreach (var item in droneCommandList)
            {
                switch (item.OrderDirection)
                {
                    //X - POSITIVE
                    case "RIGHT":
                        cmdVector = String.Concat(Convert.ToString(item.OrderDistance), ",0", ",0", " --> ");
                        dx = dx + item.OrderDistance;
                        droneVectorArr[0] = Convert.ToString(dx);
                        bool verifyCrashFlag1 = CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag1)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else
                        {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;
                    //X - NEGATIVE
                    case "LEFT":
                        cmdVector = String.Concat("-", Convert.ToString(item.OrderDistance), ",0", ",0", " --> ");
                        dx = dx - item.OrderDistance;
                        droneVectorArr[0] = Convert.ToString(dx);
                        bool verifyCrashFlag2 =  CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag2)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;

                    //Y - POSITIVE
                    case "FORWARD":
                        cmdVector = String.Concat("0,", Convert.ToString(item.OrderDistance), ",0", " --> ");
                        dy = dy + item.OrderDistance;
                        droneVectorArr[1] = Convert.ToString(dy);
                        bool verifyCrashFlag3 = CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag3)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else
                        {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;
                    //Y - NEGATIVE
                    case "BACKWARD":
                        cmdVector = String.Concat("0,-", Convert.ToString(item.OrderDistance), ",0", " --> ");
                        dy = dy - item.OrderDistance;
                        droneVectorArr[1] = Convert.ToString(dy);
                        bool verifyCrashFlag4 = CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag4)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else
                        {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;

                    //Z - NEGATIVE
                    case "DOWN":
                        cmdVector = String.Concat("0,", "0, -", Convert.ToString(item.OrderDistance), " --> ");
                        dz = dz - item.OrderDistance;
                        droneVectorArr[2] = Convert.ToString(dz);
                        bool verifyCrashFlag5 = CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag5)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else
                        {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;
                    //Z - POSITIVE
                    case "UP":
                        cmdVector = String.Concat("0,", "0,", Convert.ToString(item.OrderDistance), " --> ");
                        dz = dz + item.OrderDistance;
                        droneVectorArr[2] = Convert.ToString(dz);
                        bool verifyCrashFlag6 = CheckForCrashSequence(worldVectorArr, droneVectorArr);
                        if (!verifyCrashFlag6)
                        {
                            droneVector = String.Concat(Convert.ToString(dx), ",", Convert.ToString(dy), ",", Convert.ToString(dz));
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                        }
                        else
                        {
                            droneVector = "CRASH IMMINENT - AUTOMATIC COURSE CORRECTION";
                            Console.WriteLine(String.Concat(cmdVector, droneVector));

                            cmdVector = String.Concat("-", Convert.ToString(orgDx), ",0,", "0 --> ");
                            droneVectorArr[0] = "0";
                            droneVectorArr[1] = Convert.ToString(orgDy);
                            droneVectorArr[2] = Convert.ToString(orgDz);
                            droneVector = String.Concat(droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2]);
                            Console.WriteLine(String.Concat(cmdVector, droneVector));
                            return false;
                        }
                        break;

                    case "default":
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// Method which will check whether the vectors is near crash scenario.
        /// </summary>
        /// <param name="worldVectorArr">World vector list</param>
        /// <param name="droneVectorArr">Changing drone vector list</param>
        /// <returns>True or false on the crash test</returns>
        public bool CheckForCrashSequence(List<string> worldVectorArr, List<string> droneVectorArr)
        {
            bool status = false;
            for (int i = 0; i < droneVectorArr.Count; i++)
            {
                int droneVector = Convert.ToInt32(droneVectorArr[i]);
                int worldVector = Convert.ToInt32(worldVectorArr[i]);
                if (droneVector < 0 || droneVector >= worldVector)
                {
                    status = true;
                    break;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }
    }
}
