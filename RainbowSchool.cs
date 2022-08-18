using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace RainbowSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> teacherData = new List<string>();
            //string teacherID,teacherName,teacherSection;
            string filePath = @"C:\Users\shivtej.deshmukh\source\repos\RainbowSchool\RainbowSchool\TextFile1.txt";
            teacherData = File.ReadAllLines(filePath).ToList();
            int choice=0;
            Console.WriteLine("Welcome to Rainbow School Teacher Database ");
            while (choice!=5)
            {
                Console.WriteLine("Select your option\n1.\tAdd\n2.\tUpdate\n3.\tDelete\n4.\tView\n5.\tExit\n\n");
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        RainbowSchool.Store.addData(teacherData,filePath);
                        break;

                    case 2:
                        RainbowSchool.Update.updateData(teacherData,filePath);
                        break;

                    case 3:
                        RainbowSchool.Delete.deleteData(teacherData,filePath);
                        break;

                    case 4:
                        RainbowSchool.Retrieve.viewData(teacherData,filePath);
                        break;
                    
                    case 5:
                        Console.WriteLine("Thank You for using Rainbow School Teacher Database!!\n");
                        break;

                    default:
                        Console.WriteLine("Please enter correct option!!");
                        break;
                }
                
            }
            
        }
    }

    class Store
    {
        public static void addData(List<string> teacherData,string filePath)
        {
            string teacherID,teacherName,teacherSection;
            Console.WriteLine("");
            Console.WriteLine("Enter ID");
            teacherID = Console.ReadLine();
            Console.WriteLine("Enter Name");
            teacherName = Console.ReadLine();
            Console.WriteLine("Enter Section");
            teacherSection = Console.ReadLine();
            string data = teacherID+"\t"+teacherName+"\t\t"+teacherSection;
            teacherData.Add(data);
            File.WriteAllLines(filePath,teacherData);


            Console.WriteLine("Data Added Successfully\n");


        }
    }

    class Update
    {
        public static void updateData(List<string> teacherData,string filePath)
        {
            string teacherID,teacherName,teacherSection;
            Console.Write("Enter Teacher ID to Update Data\n");
            teacherID = Console.ReadLine();
            foreach (String linedata in teacherData)
                {
                    if (linedata.Trim().StartsWith(teacherID))
                    {
                        teacherData.Remove(linedata);
                        File.WriteAllLines(filePath, teacherData);
                        break;
                    }
                }
            Console.WriteLine("Enter Name");
            teacherName = Console.ReadLine();
            Console.WriteLine("Enter Section");
            teacherSection = Console.ReadLine();
            string data = teacherID+"\t"+teacherName+"\t\t"+teacherSection;
            teacherData.Add(data);
            File.WriteAllLines(filePath,teacherData);
            Console.WriteLine("Data Updated Successfully\n");


        }
    }

    class Retrieve
    {
        public static void viewData(List<string> teacherData,string filePath)
        {
            int index=0;
            Console.WriteLine("Index\tID\tNAME\t\tSECTION\n"); 
            foreach (String linedata in teacherData)
            {
                index++;
                Console.WriteLine(index+"\t"+linedata);
            }
            Console.WriteLine("");

        }
        
    }

    class Delete
    {
        public static void deleteData(List<string> teacherData,string filePath)
        {
            Console.Write("Enter Teacher ID to remove Data\n");
            string teacherID = Console.ReadLine();
            foreach (String linedata in teacherData)
                {
                    if (linedata.Trim().StartsWith(teacherID))
                    {
                        teacherData.Remove(linedata);
                        File.WriteAllLines(filePath, teacherData);
                        break;
                    }
                }
            Console.WriteLine("Data Deleted Successfully\n");
        }
    }
}