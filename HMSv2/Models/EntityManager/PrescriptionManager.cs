using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSv2.Models.ViewModel;
using HMSv2.Models.DB;
namespace HMSv2.Models.EntityManager
{
    public class PrescriptionManager
    {

        public void AddDiagBill(Prescription p,int pid)
        {
            using (HMS_DBEntities db = new HMS_DBEntities())
            {
                Diagnosis diag = new Diagnosis();
                diag.Symptoms = p.Symptoms;
                diag.AdministratedBy = p.AdminBy;
                diag.DateOfDiagnosis = p.DateOfDiagnosis;
                diag.DiagnosisProvided = p.DiagnosisProvided;
                diag.FollowUpDate = p.FUdate;
                diag.FollowUpRequired = p.FUrequired;
                diag.PatientID = pid;

                Billing b = new Billing();
                b.BillAmount = p.Bill;
                b.ModeOfPayment = p.Mode;
                b.CardNo = p.CardNo;
                diag.BillID = b.BillID;

                db.Diagnosis.Add(diag);
                db.Billing.Add(b);
                db.SaveChanges();

            }
        }
    }
}