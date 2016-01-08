using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class PatientAdmission
    {
        public int PatientAdmissionID { get; set; }
        [StringLength(20)]
        [DisplayName("Register No")]
        public string RegisterNo { get; set; }
        [DisplayName("Date of Admission")]
        public DateTime DateOfAdmission { get; set; }
        [StringLength(10)]
        [DisplayName("Type of Admission")]
        public string AdmissionType { get; set; }
        [DisplayName("Reason for Admission")]
        public string ReasonForAdmission { get; set; }

        [Required(ErrorMessage = "Surname Required")]
        [StringLength(50, ErrorMessage = "Surname Length should be less than 50")]

        public string Surname { get; set; }

        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First name Length should be less than 50")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [DisplayName("Known as")]
        public String KnownAs { get; set; }
        public String Address { get; set; }
        [Required(ErrorMessage = "Date of Birth Required")]
       // [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime DOB { get; set; }
        [DisplayName("Martial Status")]
        public string MartialStatus { get; set; }
        public string Sex { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        [DisplayName("Name")]
        public string NextOfKin1Name { get; set; }
        [DisplayName("Address")]
        public string NextOfKin1Address { get; set; }
        [DisplayName("Relation")]
        public string NextOfKin1Relation { get; set; }
        [DisplayName("Phone")]
        public string NextOfKin1Phone { get; set; }
        [DisplayName("Name")]
        public string NextOfKin2Name { get; set; }
        [DisplayName("Address")]
        public string NextOfKin2Address { get; set; }
        [DisplayName("Relation")]
        public string NextOfKin2Relation { get; set; }
        [DisplayName("Phone")]
        public string NextOfKin2Phone { get; set; }
        [DisplayName("Medical Card No")]
        public string MedicalCardNo { get; set; }
        public bool isSmoker { get; set; }
        public bool isAlcoholic { get; set; }
        public string Hobbies { get; set; }
        public bool Staus { get; set; }

        [DisplayName("Medical History")]
        public string MedicalHistory { get; set; }
        [DisplayName("Surgical History")]
        public string SurgicalHistory { get; set; }

        public string Allergies { get; set; }
        [DisplayName("MRSA Status")]
        [StringLength(20)]
        public string MRSAStatus { get; set; }

        public double Height { get; set; }
        public double weight { get; set; }
        [StringLength(20)]
        public string BP { get; set; }
        public int Pulse { get; set; }
        public int Resps { get; set; }
        public double Temperature { get; set; }

        [DisplayName("Ward")]
        public int WardID { get; set; }
        [DisplayName("Bed No")]
        public string BedNo { get; set; }

        //Navigation Properties
        public int CustomerID { get; set; }
        [DisplayName("GP")]
        public int GeneralPractitionerID { get; set; }

        //to store picture
         [DisplayName("Profile Picture")]
        public byte[] ProfilePicture { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }


        [ForeignKey("GeneralPractitionerID")]
        public virtual GeneralPractitioner GeneralPractitioner { get; set; }

        [ForeignKey("WardID")]
        public virtual Ward Ward { get; set; }

        public virtual List<PatientAppointment> PatientAppointments { get; set; }
    

    }
}
