namespace Patients.Models
{
    /// <summary>
    /// A class <c>Patient</c> which represents the patient
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// A property which represents the name of the patient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A property which represents the age of the patient
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// A property which represents the blood group of the patient
        /// </summary>
        public string BloodGroup { get; set; }
    }
}
