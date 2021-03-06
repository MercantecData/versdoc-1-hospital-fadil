﻿using System;

namespace AnimalHospital
{
    class Program
    {
        public static Hospital hospital;
        static void Main(string[] args)
        {
            hospital = InitializeHospital();
            while (MainMenu()) {}

            Console.WriteLine("Goodbye!");
        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to {0}. You have the following options:", hospital.name);
            Console.WriteLine("1. Admit a patient to the hospital");
            Console.WriteLine("2. Discharge a patient");
            Console.WriteLine("3. See a list of all patients in the hospital");
            Console.WriteLine("4. See a list of all doctors in the hospital");
            Console.WriteLine("5. Assign a specific doctor to a specific patient");
            Console.WriteLine("0. Quit the Program");
            Console.WriteLine();

            
            var k = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (k == '1')
            {
                AdmitPatient();
            } 
            else if(k == '2')
            {
                DischargePatient();
            } 
            else if(k == '3')
            {
                ListPatients();
            }
            else if (k == '4')
            {
                ListDoctors();
            }
            else if (k == '5')
            {
                AssignDoctor();
            }
            else if (k == '0')
            {
                return false;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        static void AdmitPatient()
        {
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine();

            Console.WriteLine("What is the patients age?");
            while(!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("You must write a number, try again");
            }

            new Patient(name, age).AdmitTo(hospital);
        }

        static void DischargePatient()
        {
            string name;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine();

            hospital.DischargePatient(hospital.FindPatientByName(name));

        }

        static void ListPatients()
        {
            hospital.ListPatients();

        }

        static void AssignDoctor()
        {
            Console.WriteLine("What is the name of the doctor?");
            string doctor = Console.ReadLine();
            Console.WriteLine("Patient name:");
            string patient = Console.ReadLine();
            hospital.AssignDoctor(hospital.FindDoctorByName(doctor), hospital.FindPatientByName(patient));

        }

        static void ListDoctors()
        {
            hospital.ListDoctors();
        }

        static Hospital InitializeHospital()
        {
            Hospital hospital = new Hospital("Animal Hospital");

            hospital.doctors.AddRange(new Doctor[]
            {
                new Doctor("Matt Tennant", "Spinal Injury"),
                new Doctor("David Smith", "Knee Injury"),
                new Doctor("Jodie Tyler", "Oncology"),
                new Doctor("Rose Whitaker", "Intensive Care")
            });

            return hospital;
        }
    }
}
