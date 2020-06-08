using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Hospital
    {
        public string name;

        public List<Patient> patients = new List<Patient>();
        public List<Doctor> doctors = new List<Doctor>();

        public Hospital(string name)
        {
            this.name = name;
        }

        public void AdmitPatient(Patient patient)
        {
            if(patients.Contains(patient))
            {
                Console.WriteLine("Patient already admitted to {0}.", name);
            } else
            {
                patients.Add(patient);
                Console.WriteLine("{0} was admitted to {1} successfully", patient.name, name);
            }
        }

        public void DischargePatient(Patient patient)
        {
            if (!patients.Contains(patient))
            {
                Console.WriteLine("Patient not in this hospital");
            }
            else
            {
                Console.WriteLine("{0} was discharged successfully", patient.name);
                patients.Remove(patient);
            }
        }

        public Patient FindPatientByName(string name)
        {
            foreach(var p in patients)
            {
                if(p.name == name)
                {
                    return p;
                }
            }

            return null;
        }

        public void ListPatients()
        {
            Console.WriteLine("Name" + "  " + "Age");
            {
            foreach (Patient patient in patients)
                
                Console.WriteLine(patient.name + "  " + patient.age);
            }
        }

        public void ListDoctors()
        {
            Console.WriteLine("Name" + "  " + "Speciality");
            foreach (Doctor doctor in doctors)

            {
                Console.WriteLine(doctor.name + "  " + doctor.speciality);
            }
        }
        public Doctor FindDoctorByName(string name)
        {
            foreach (var d in doctors)
            {
                if (d.name == name)
                {
                    return d;
                }
            }

            return null;
        }

        public void AssignDoctor(Doctor doctor, Patient patient)
        {
            if (!patients.Contains(patient) || !doctors.Contains(doctor))
            {
                Console.WriteLine("Doctor or patient not in this hospital. Could not assign.");
            }
            else
            {

                foreach (Doctor doc in doctors)
                {
                    if (doc == doctor)
                    {
                        Console.WriteLine("Assigned doctor to patient");
                        doc.assignedPatients.Add(patient);
                    }
                }
            }
        }
    }
}
