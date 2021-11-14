using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeV1
{
    public class Vector
    {
        public bool VectorMovement(List<string> worldVectorArr, List<string> droneVectorArr, List<DroneCmdViewModel> droneCommandList)
        {
            Console.WriteLine(string.Concat("Drone starts at: (", droneVectorArr[0], ",", droneVectorArr[1], ",", droneVectorArr[2], ")"));
            string cmdVector = ""; string droneVector = "";
            int wx = Convert.ToInt32(worldVectorArr[0]);
            int wy = Convert.ToInt32(worldVectorArr[1]);
            int wz = Convert.ToInt32(worldVectorArr[2]);

            int orgDx = Convert.ToInt32(droneVectorArr[0]);
            int orgDy = Convert.ToInt32(droneVectorArr[1]);
            int orgDz = Convert.ToInt32(droneVectorArr[2]);

            int dx = Convert.ToInt32(droneVectorArr[0]);
            int dy = Convert.ToInt32(droneVectorArr[1]);
            int dz = Convert.ToInt32(droneVectorArr[2]);

            droneCommandList = droneCommandList.OrderBy(a => a.OrderNo).ToList(); 
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
