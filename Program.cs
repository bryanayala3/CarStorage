/*
 * Program ID: CarStorage
 * 
 * Prupose: Create a Storage List
 * 
 * Revision history:
 * Bryan Ayala  November 20,2022
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4JRBA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string brandString;
            bool keepGoing;
            string option;
            string brandInput;
            bool brandValidation;
            string modelString;
            int modelNumber;
            string NewCar;
            bool noneExist;
            bool newRecordExist;
            string userDone;
            string carEdit;
            bool recordExist;
            string carDelete;
            bool enteredTheCatch;
            int k;

            //Initialie varibles
            keepGoing = true;
            option = "";
            brandValidation = true;
            modelNumber = 0;
            noneExist = true;
            newRecordExist = true;
            enteredTheCatch = false;
            k = 0;

            Console.WriteLine("This program is to save the information of 20 cars: ");
            Console.WriteLine("Introduce the brands of three cars: (e.g. BMW, Mercedes Benz, Toyota");
            string[] brandAyala = new string[3];

            for (int i = 0; i < brandAyala.Length; i++)
            {
                brandString = Console.ReadLine();
                brandAyala[i] = brandString;
            }

            string[] storeData = new string[20];
            for (int i = 0; i < storeData.Length; i++)
            {
                storeData[i] = "New Record";
            }

            //Menu of options:

            do
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("");
                Console.WriteLine("A. Add new Car details -Brand Name & Model (for example “Ford SUV”)\nB.Edit existing Car details(Brand Name & Model)\nC.Display all Cars in store(display the Brand Name & Model)\nD.Delete Car Information\nE.Exit the program");
                Console.WriteLine("");
                Console.WriteLine("Please choice one of the above options: ");
                option = Console.ReadLine();

                if (option == "A")
                {
                    do
                    {
                        do
                        {
                            Console.WriteLine("Enter one of the next car's brand:");

                            foreach (string i in brandAyala)
                            {
                                Console.WriteLine(i);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Input the brand:");
                            brandInput = Console.ReadLine();
                            brandValidation = brandAyala.Contains<string>(brandInput);

                            //Validation of a correct brand
                            while (brandValidation == false)
                            {
                                Console.WriteLine("ERROR. The brand Entered aren't in the list. Please try again with exactly Capltal letters");
                                brandInput = Console.ReadLine();
                                brandValidation = brandAyala.Contains<string>(brandInput);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Enter the number of the model:\nSedan (1)\nHatchback (2)\nSUV (3)\nPickup Truck(4)");
                            modelString = Console.ReadLine();

                            //Validation of a correct model
                            while (keepGoing)
                            {
                                try
                                {
                                    modelNumber = int.Parse(modelString);
                                    if (modelNumber < 1 || modelNumber > 4)
                                    {
                                        throw new ArgumentOutOfRangeException();
                                    }
                                    enteredTheCatch = false;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("ERROR. The entered model isn't between the listed above. Try again:");
                                    modelString = Console.ReadLine();
                                    enteredTheCatch = true;
                                }
                         
                                if (enteredTheCatch==false)
                                {
                                    keepGoing = false;
                                }
                            }
                            //Normalize variable
                            keepGoing = true;

                            //Concatenate the brand & model
                            NewCar = brandInput + "-" + modelString;

                            //Validation if the input already exist
                            keepGoing = storeData.Contains<String>(NewCar);

                            if (keepGoing)
                            {
                                Console.WriteLine("Error Car record already exists. Try Again");
                                Console.WriteLine();
                            }



                        } while (keepGoing);

                        //Normalize variable
                        keepGoing = true;

                        //Validation if the list have avaible space (NONE or New Record)
                        noneExist = storeData.Contains<string>("NONE");
                        newRecordExist = storeData.Contains<string>("New Record");

                        if (noneExist)
                        {
                            int indexNone = Array.IndexOf(storeData, "NONE");

                            storeData[indexNone] = NewCar;

                            Console.WriteLine();
                            Console.WriteLine("New brand saved correctly in the position of a deleted brand indicated by “NONE”");
                            Console.WriteLine();

                        }
                        else if (newRecordExist)
                        {

                            int indexNew = Array.IndexOf(storeData, "New Record");

                            storeData[indexNew] = NewCar;

                            Console.WriteLine();
                            Console.WriteLine("New Brand saved correctly in a new position");
                            Console.WriteLine();
                        }

                        else
                        {
                            Console.WriteLine("You are entered 20 Records, please delete someone to continue adding.");

                            keepGoing = false;
                        }

                        if (keepGoing)
                        {
                            Console.WriteLine("Write DONE if you want finish the input of new Brand\nIf you want Continue Press enter.");
                            Console.WriteLine();
                            userDone = Console.ReadLine();

                            if (userDone == "DONE")
                            {
                                keepGoing = false;
                            }

                        }


                    } while (keepGoing);

                    //Normalize variable
                    keepGoing = true;
                }

                else if (option == "B")
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("To edit existing Car details, Please Enter the Car in format Brand-model (e.g Porshe-2):");
                        carEdit = Console.ReadLine();

                        //Validation if the record already exist
                        recordExist = storeData.Contains<string>(carEdit);

                        if (recordExist)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Brand information found");
                            Console.WriteLine("Please Enter updated information");
                            Console.WriteLine("Input the brand:");
                            brandInput = Console.ReadLine();
                            brandValidation = brandAyala.Contains<string>(brandInput);

                            //Validation of a correct brand
                            while (brandValidation == false)
                            {
                                Console.WriteLine("ERROR. The brand Entered aren't in the list. Pleas try again with exactly the same Capital letters listed above");
                                brandInput = Console.ReadLine();
                                brandValidation = brandAyala.Contains<string>(brandInput);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Enter the number of the model:\nSedan (1)\nHatchback (2)\nSUV (3)\nPickup Truck(4)");
                            modelString = Console.ReadLine();

                            //Validation of a correct model
                            while (keepGoing)
                            {
                                try
                                {
                                    modelNumber = int.Parse(modelString);
                                    if (modelNumber < 1 || modelNumber > 4)
                                    {
                                        throw new ArgumentOutOfRangeException();
                                    }
                                    enteredTheCatch = false;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("ERROR. The entered model isn't between the listed above. Try again:");
                                    modelString = Console.ReadLine();
                                    enteredTheCatch = true;
                                }

                                if (enteredTheCatch == false)
                                {
                                    keepGoing = false;
                                }
                            }
                            //Normalize variable
                            keepGoing = true;

                            //Concatenate the brand & model
                            NewCar = brandInput + "-" + modelString;



                            int index = Array.IndexOf(storeData, carEdit);

                            storeData[index] = NewCar;

                            Console.WriteLine();
                            Console.WriteLine("The record is updated. Please press Enter to return at main menu");
                            keepGoing = false;
                            Console.ReadKey();

                        }

                        else if (recordExist == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Brand record not found for that entry");
                            Console.WriteLine();
                            Console.WriteLine("Please press Enter to return to the main menu");
                            keepGoing = false;
                            Console.ReadKey();
                        }


                    } while (keepGoing);
                    //normalize variable
                    keepGoing = true;
                }

                else if (option == "C")
                {

                    //Creation a list to save only the brands saved in the array, it is avoiding "NONE" string
                    List<String> savedBrands = new List<string>();

                    foreach(string i in storeData)
                    {
                        if(i!="NONE" && i!="New Record")
                        {
                            savedBrands.Add(i);
                        }
                    }
                    k = 1;
                    foreach(string i in savedBrands)
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine(k + ") " + i);
                        Console.WriteLine();
                        k++;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Please press Enter to return to the main Menu");
                    Console.ReadKey();

                }

                else if (option == "D")
                {
                    Console.WriteLine();
                    Console.WriteLine("To delete existing Car details, Please Enter the Car in format Brand-model (e.g Porshe-2):");
                    carDelete = Console.ReadLine();

                    //Validation if the record already exist
                    recordExist = storeData.Contains<string>(carDelete);

                    if (recordExist)
                    {
                        while (keepGoing)
                        {
                            //Option for delete a Record
                            Console.WriteLine();
                            Console.WriteLine("Brand information found.\nAre you sure you want to delete press 'Y' or 'N' ");
                            option = Console.ReadLine();

                            if (option == "Y")
                            {
                                int index = Array.IndexOf(storeData, carDelete);

                                storeData[index] = "NONE";

                                keepGoing = false;

                                Console.WriteLine();
                                Console.WriteLine("Brand was delete");
                                Console.WriteLine();
                            }

                            else if (option == "N")
                            {
                                Console.WriteLine();
                                keepGoing = false;
                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Entered option isn't valid. Try again");
                                Console.WriteLine();
                            }
                        }

                        //Normalize variable
                        keepGoing = true;
                        option = "";

                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Brand record not found for that entry");
                        Console.WriteLine();
                    }



                }

                else if (option == "E")
                {
                    Console.WriteLine();
                    Console.WriteLine("You are leaving of the program. Bye!");
                    Console.WriteLine();

                    keepGoing = false;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR. The Entered option isn't correct. Try again.");
                }


            } while (keepGoing);
            Console.ReadKey();
        }


    }
}
