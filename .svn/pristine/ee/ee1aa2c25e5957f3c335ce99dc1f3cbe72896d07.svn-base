using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VetTux_Converter.Linq;
using VetTux_Converter.General;

namespace VetTux_Converter.VetTux
{
    public partial class frmVetTuxConversion : DevExpress.XtraEditors.XtraForm
    {
        private VetTuxDataContextDataContext myCyberDB = new VetTuxDataContextDataContext();        
        private VetmasterDataContextDataContext myVetmasterDB = new VetmasterDataContextDataContext();
        private int counter = 0, patientCounter = 0, balanceCounter = 0, patientNoteCounter = 0, inventoryCounter = 0, patientWeightCounter = 0;
        int totalCustomers = 0, totalPatients = 0, totalBalances = 0, totalPatientNotes = 0, totalInventory = 0, totalPatientWeight = 0;
        int progressPercentage = 0;

        public frmVetTuxConversion()
        {
            InitializeComponent();

        }

        private void ConvertCustomers()
        {
            counter = 0;

            var owners = from owner in myCyberDB.owners
                         select owner;
            totalCustomers = owners.Count();

            foreach (var owner in owners)
            {
                Linq.Customer vmCustomer = new Customer();

                if (owner.Title != null)
                {
                    owner.Title = owner.Title.Replace(".", "").Trim();

                    var vmTitle = myVetmasterDB.CustomerTitles.Where(i => i.Name.ToUpper() == owner.Title.ToUpper()).FirstOrDefault();
                    if (vmTitle != null)
                        vmCustomer.TitleID = vmTitle.ID;
                    else
                        vmCustomer.TitleID = 1;
                }

                int langID;
                if (int.TryParse(owner.Language.ToString(), out langID))
                    vmCustomer.LanguageID = langID + 1; // 0 is english, 1 is afrikaans
                else
                    vmCustomer.LanguageID = 1; // default to english


                vmCustomer.TermsID = 2; // Account customers
                vmCustomer.StatusID = 1; // All active
                vmCustomer.ProfileID = 1; // Normal profile

                if (owner.Initials != null)
                    vmCustomer.FirstName = owner.Initials;
                else
                    vmCustomer.FirstName = string.Empty;


                //if (owner.Surname == null)
                //    vmCustomer.LastName = string.Empty;
                //else
                //    vmCustomer.LastName = owner.Surname;


                // The surname was encrypted, but we do not accept empty strings for the surname, so use a space
                vmCustomer.LastName = " ";

                vmCustomer.Code = owner.AccountNumber.ToString();
                vmCustomer.VATNumber = owner.VatNo;
                vmCustomer.IDNumber = owner.IDno;
                vmCustomer.Comment = owner.Notes;

                // POSTAL ADDRESS
                if (owner.PostalAddr != null)
                {
                    string[] myAddress = new string[4];
                    string[] stringSeparators = new string[] { "\n" };
                    string myPostalAddress4 = string.Empty;

                    myAddress = owner.PostalAddr.Split(stringSeparators, StringSplitOptions.None);

                    if (myAddress.Length > 0)
                    {
                        if (myAddress[0].Length > 50)
                            vmCustomer.PostalLine1 = myAddress[0].Substring(0, 49);
                        else
                            vmCustomer.PostalLine1 = myAddress[0].ToString();
                    }

                    if (myAddress.Length > 1)
                    {
                        if (myAddress[1].Length > 50)
                            vmCustomer.PostalLine2 = myAddress[1].Substring(0, 49);
                        else
                            vmCustomer.PostalLine2 = myAddress[1].ToString();
                    }

                    if (myAddress.Length > 2)
                        vmCustomer.PostalLine3 = myAddress[2].ToString();

                    if (myAddress.Length > 3)
                    {
                        for (int i = 3; i < myAddress.Length; i++)
                        {
                            myPostalAddress4 += string.Concat(myAddress[i], " ");
                        }
                        if (myPostalAddress4.Length > 50)
                            vmCustomer.PhysicalLine4 = myPostalAddress4.Substring(0, 49);
                        else
                            vmCustomer.PhysicalLine4 = myPostalAddress4;
                    }
                }


                // PHYSICAL ADDRESS
                if (owner.PhysAddr != null)
                {
                    string[] myAddress = new string[4];
                    string[] stringSeparators = new string[] { "\n" };
                    string myPhysicalAddress4 = string.Empty;

                    myAddress = owner.PhysAddr.Split(stringSeparators, StringSplitOptions.None);

                    if (myAddress.Length > 0)
                    {
                        if (myAddress[0].Length > 50)
                            vmCustomer.PhysicalLine1 = myAddress[0].Substring(0, 49);
                        else
                            vmCustomer.PhysicalLine1 = myAddress[0].ToString();
                    }

                    if (myAddress.Length > 1)
                    {
                        if (myAddress[1].Length > 50)
                            vmCustomer.PhysicalLine2 = myAddress[1].Substring(0, 49);
                        else
                            vmCustomer.PhysicalLine2 = myAddress[1].ToString();
                    }

                    if (myAddress.Length > 2)
                        vmCustomer.PhysicalLine3 = myAddress[2].ToString();

                    if (myAddress.Length > 3)
                    {
                        for (int i = 3; i < myAddress.Length; i++)
                        {
                            myPhysicalAddress4 += string.Concat(myAddress[i], " ");
                        }
                        if (myPhysicalAddress4.Length > 50)
                            vmCustomer.PhysicalLine4 = myPhysicalAddress4.Substring(0, 49);
                        else
                            vmCustomer.PhysicalLine4 = myPhysicalAddress4;
                    }
                }


                if (owner.Cell.Length > 50)
                    vmCustomer.CellPhone = owner.Cell.Substring(0, 50);
                else
                    vmCustomer.CellPhone = owner.Cell;
                
                vmCustomer.HomePhone = owner.TelHome;
                vmCustomer.WorkPhone = owner.TelWork;
                vmCustomer.Fax = string.Empty;
                vmCustomer.EMail = owner.Email;
                vmCustomer.VehicleReg = string.Empty;
                vmCustomer.Syndicate = false; // Not syndicate
                vmCustomer.CreditLimitation = false;
                vmCustomer.CreditLimit = 0;
                vmCustomer.IsLoyalty = true;
                vmCustomer.TotalLoyaltyPoints = 0;
                vmCustomer.CreateDate = DateTime.Now;
                vmCustomer.Updated = DateTime.Now;
                vmCustomer.Created = DateTime.Now;
                vmCustomer.Modified = DateTime.Now;
                vmCustomer.RowVersion = 1;
                vmCustomer.Booked = false;
                vmCustomer.Version = Guid.NewGuid();

                if (vmCustomer.EMail != String.Empty)
                {
                    vmCustomer.BillToPostal = false;
                    vmCustomer.BillToEMail = true;
                    vmCustomer.BillToPhysical = false;
                }
                else
                {
                    if (vmCustomer.PhysicalLine1 != string.Empty)
                    {
                        vmCustomer.BillToPostal = false;
                        vmCustomer.BillToEMail = false;
                        vmCustomer.BillToPhysical = true;
                    }
                    else
                    {
                        vmCustomer.BillToPostal = true;
                        vmCustomer.BillToEMail = false;
                        vmCustomer.BillToPhysical = false;
                    }
                }

                myVetmasterDB.Customers.InsertOnSubmit(vmCustomer);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++counter * 100 / totalCustomers; // counter also gets incremented for next iteration
                backgroundWorkerCustomer.ReportProgress(progressPercentage);
            }
        }

        private void convertBalances()
        {
            balanceCounter = 0;
            var balances = from bal in myCyberDB.receipts
                           select bal;

            var customers = from cust in myVetmasterDB.Customers
                            select cust;

            totalBalances = customers.Count();

            foreach(var myCustomer in customers)
            {
                Linq.Sale vmBalance = new Sale();
                vmBalance.SaleDate = DateTime.Now;
                vmBalance.SourceDocument = "Opening Balance";
                vmBalance.TypeID = 10; // For opening balances


                vmBalance.CustomerID = myCustomer.ID;

                vmBalance.Description = "Opening Balance";
                vmBalance.Comment = "Opening Balance";

                // Get the balance by looking at the latest payment - the balance is located there
                decimal myBalanceAmount = 0;
                var balanceAmount = balances.Where(i => i.AccountNumber.ToString() == myCustomer.Code).OrderByDescending(d=>d.MyDate).FirstOrDefault();
                myBalanceAmount = balanceAmount != null ? (decimal)balanceAmount.Balance : 0;
                vmBalance.AmountExclusive = myBalanceAmount;


                vmBalance.TaxAmount = 0;
                vmBalance.UserID = 2; // For user dataconversion
                vmBalance.Reference = 0;
                vmBalance.Total = myBalanceAmount;
                vmBalance.ShiftID = 0; // No shift
                vmBalance.Created = DateTime.Now;
                vmBalance.Modified = DateTime.Now;
                vmBalance.RowVersion = 1;
                vmBalance.BranchID = 1;

                myVetmasterDB.Sales.InsertOnSubmit(vmBalance);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++balanceCounter * 100 / totalBalances; // counter is also incremented for next iteration

                backgroundWorkerBalance.ReportProgress(progressPercentage);

            }
        }

        private void ConvertSpecies()
        {
            var Species = from b in myCyberDB.patients
                          group b by b.Species.ToUpper() into bg
                          select bg.FirstOrDefault();

            var vmSpecies = myVetmasterDB.Species;

            foreach(var specie in Species)
            {
                var specieExists = vmSpecies.Where(i => i.Name.ToUpper().Trim().Equals(specie.Species.ToUpper().Trim())).FirstOrDefault();
                if(specieExists == null)
                {
                    Linq.Specie myNewSpecie = new Linq.Specie();
                    myNewSpecie.Name = specie.Species;
                    myNewSpecie.Description = string.Empty;
                    myNewSpecie.Created = DateTime.Now;
                    myNewSpecie.Modified = DateTime.Now;
                    myNewSpecie.RowVersion = 1;

                    myVetmasterDB.Species.InsertOnSubmit(myNewSpecie);
                    myVetmasterDB.SubmitChanges();
                }

            }
        }

        private void ConvertBreeds()
        {
            var Breeds = from b in myCyberDB.patients
                         group b by b.Breed.ToUpper() into bg
                         select bg.FirstOrDefault();

            var vmBreeds = myVetmasterDB.Breeds;

            foreach(var breed in Breeds)
            {
                var breedExists = myVetmasterDB.Breeds.Where(i => i.Name.ToUpper().Trim().Equals(breed.Breed.ToUpper().Trim())).FirstOrDefault();
                if(breedExists == null)
                {
                    Linq.Breed myNewBreed = new Linq.Breed();
                    myNewBreed.Name = breed.Breed;
                    var myNewSpecieID = myVetmasterDB.Species.Where(s => s.Name == breed.Species).FirstOrDefault();
                    if (myNewSpecieID != null)
                        myNewBreed.SpecieID = myNewSpecieID.ID;
                    else
                        continue;

                    myNewBreed.Description = string.Empty;
                    myNewBreed.Created = DateTime.Now;
                    myNewBreed.Modified = DateTime.Now;
                    myNewBreed.RowVersion = 1;

                    myVetmasterDB.Breeds.InsertOnSubmit(myNewBreed);
                    myVetmasterDB.SubmitChanges();
                }
            }
        }

        private void convertPatients()
        {
            ConvertSpecies();
            ConvertBreeds();

            patientCounter = 0;

            var customers = from cust in myVetmasterDB.Customers
                            select cust;

            var patients = from pat in myCyberDB.patients
                           select pat;

            totalPatients = patients.Count();

            foreach (var patient in patients)
            {
                Linq.Patient vmPatient = new Patient();

                //vmPatient.Name = patient.Name;
                // The patient name was encrypted, and we do not allow nulls, so use a space for the name
                vmPatient.Name = " ";

                if (patient.AccountNumber == null)
                {
                    patientCounter++;
                    continue;
                }
                else
                {
                    var myCustomer = customers.Where(i => i.Code == patient.AccountNumber.ToString()).FirstOrDefault();
                    if (myCustomer != null)
                        vmPatient.CustomerID = myCustomer.ID;
                    else
                    {
                        patientCounter++;
                        continue;
                    }
                }


                //vmPatient.BreedID = 245; // Do this
                var myBreed = myVetmasterDB.Breeds.Where(b => b.Name == patient.Breed).FirstOrDefault();
                if (myBreed != null)
                    vmPatient.BreedID = myBreed.ID;
                else
                    vmPatient.BreedID = 245;

                if (patient.Sex != null)
                {
                    switch (patient.Sex.ToUpper())
                    {
                        case "MALE":
                            vmPatient.PatientGenderID = 1;
                            vmPatient.Sterile = false;
                            break;
                        case "FEMALE":
                            vmPatient.PatientGenderID = 2;
                            vmPatient.Sterile = false;
                            break;
                        case "NEUTERED":
                            vmPatient.PatientGenderID = 1;
                            vmPatient.Sterile = true;
                            break;
                        case "SPAYED":
                            vmPatient.PatientGenderID = 2;
                            vmPatient.Sterile = true;
                            break;
                        default:
                            vmPatient.PatientGenderID = 1;
                            vmPatient.Sterile = false;
                            break;
                    }
                }
                else
                {
                    vmPatient.PatientGenderID = 1;
                    vmPatient.Sterile = false;
                }

                if (patient.Status == "Y")
                    vmPatient.PatientStatusID = 5;
                else
                    vmPatient.PatientStatusID = 1;

                vmPatient.ColourMarkings = patient.Colour;

                vmPatient.AccurateDOB = false;

                if (patient.BirthDay == null)
                    vmPatient.DOB = DateTime.Now;
                else
                    vmPatient.DOB = (DateTime)patient.BirthDay;

                vmPatient.BloodDonor = false;
                vmPatient.AccurateDOD = false;
                vmPatient.DOD = DateTime.Now;
                vmPatient.Photo = null;
                vmPatient.Location = patient.PetNumber.ToString();
                vmPatient.Comment = String.Empty;
                vmPatient.CreatedDate = DateTime.Now;
                vmPatient.Identification = patient.IDno;
                vmPatient.BodyScore = (char)0;
                vmPatient.Created = DateTime.Now;
                vmPatient.Modified = DateTime.Now;
                vmPatient.RowVersion = 1;
                vmPatient.Booked = false;

                myVetmasterDB.Patients.InsertOnSubmit(vmPatient);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++patientCounter * 100 / totalPatients; // counter also gets incremented for next iteration
                backgroundWorkerPatient.ReportProgress(progressPercentage);
            }

        }


        private void convertPatientNotes()
        {
            //patientNoteCounter = 0;

            //var patientNotes = from patn in myCyberDB.PATHISTs
            //                   where patn.PACODE != 0
            //                   group patn by new { patn.PACODE, patn.PHDATETIME } into patnGroups
            //                   select patnGroups;

            //var patients = from pat in myVetmasterDB.Patients
            //               select pat;

            //totalPatientNotes = patientNotes.Count();

            //foreach (var patnGroup in patientNotes)
            //{
            //    Linq.PatientNote vmPatientNote = new PatientNote();

            //    foreach (var patn in patnGroup)
            //    {
            //        var patientQueInfo = (from patq in myCyberDB.QUEINFOs
            //                              where patq.QICODE == patn.QICODE
            //                              select patq).FirstOrDefault();

            //        if (patientQueInfo != null)
            //        {
            //            if (patientQueInfo.QISYMPTOMS != null && (patn.PHNOTE != null))
            //                vmPatientNote.Note += string.Concat(patn.PHDESC, " Notes: ", patn.PHNOTE, " Symptoms: ", patientQueInfo.QISYMPTOMS, Environment.NewLine);
            //            else if (patientQueInfo.QISYMPTOMS != null)
            //                vmPatientNote.Note += string.Concat(patn.PHDESC, " Symptoms: ", patientQueInfo.QISYMPTOMS, Environment.NewLine);
            //            else if (patn.PHNOTE != null)
            //                vmPatientNote.Note += string.Concat(patn.PHDESC, " Notes: ", patn.PHNOTE, Environment.NewLine);
            //            else
            //                vmPatientNote.Note += string.Concat(patn.PHDESC, Environment.NewLine);
            //        }
            //        else if (patn.PHNOTE != null)
            //            vmPatientNote.Note += string.Concat(patn.PHDESC, " Notes: ", patn.PHNOTE, Environment.NewLine);
            //        else
            //            vmPatientNote.Note += string.Concat(patn.PHDESC, Environment.NewLine);
            //    }

            //    var patnFirst = patnGroup.First(); // this will be used for columns that are universal in the group - the patient code and the date of the note
            //                                       // Concatenate the notes by date and customer
            //    if (patnFirst.PHDATETIME != null)
            //        vmPatientNote.NoteDate = (DateTime)patnFirst.PHDATETIME;
            //    else
            //        vmPatientNote.NoteDate = DateTime.Now;

            //    vmPatientNote.UserID = 2; // Default for user dataconversion

            //    var myPatient = patients.Where(i => i.Location == patnFirst.PACODE.ToString()).FirstOrDefault();
            //    if (myPatient != null)
            //    {
            //        vmPatientNote.PatientID = myPatient.ID;
            //    }
            //    else
            //    {
            //        patientNoteCounter++;
            //        continue;
            //    }

            //    vmPatientNote.Created = DateTime.Now;
            //    vmPatientNote.Modified = DateTime.Now;
            //    vmPatientNote.RowVersion = 1;

            //    myVetmasterDB.PatientNotes.InsertOnSubmit(vmPatientNote);
            //    myVetmasterDB.SubmitChanges();

            //    progressPercentage = ++patientNoteCounter * 100 / totalPatientNotes; // counter is incremented for the next iteration
            //    backgroundWorkerPatientNote.ReportProgress(progressPercentage);
            //}
        }

        private void InsertTaxRate()
        {
            Linq.Tax tax = new Tax();
            tax.Name = "0% VAT";
            tax.Description = "0% VAT Rate";
            tax.Rate = 0;
            tax.Created = DateTime.Now;
            tax.Modified = DateTime.Now;
            tax.RowVersion = 1;

            myVetmasterDB.Taxes.InsertOnSubmit(tax);
            myVetmasterDB.SubmitChanges();
        }

        private void ConvertProc()
        {
            // Convert Proc
            inventoryCounter = 0;
            var procs = from inv in myCyberDB.procs
                        select inv;

            totalInventory = procs.Count();

            foreach (var proc in procs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (proc.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = proc.Schedule + 1;

                if (proc.Description != null)
                    vmInventory.Description = proc.Description;
                else
                    continue;

                vmInventory.Code = proc.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)proc.Cost;
                vmInventory.SellingPriceInclusive = (decimal)proc.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = proc.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertConsult()
        {
            // Convert Consult
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.consults
                        select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertLab()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.labs
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertHospital()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.hospitals
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertInjection()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.injections
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertVaccination()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.vaccinations
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 1; // Service Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertDiagnosis()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.diagnosis
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 5; // Misc Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertGoods()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.goods
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 5; // Misc Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertMedication()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.medications
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                vmInventory.CategoryID = 5; // Misc Item

                if (inv.Tax1 == "Y")
                    vmInventory.TaxID = 1;
                else
                    vmInventory.TaxID = 2;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void ConvertStockTraceItem()
        {
            // Convert Lab
            inventoryCounter = 0;
            var invs = from inv in myCyberDB.stocktraceitems
                       select inv;

            totalInventory = invs.Count();

            foreach (var inv in invs)
            {
                Linq.Inventory vmInventory = new Inventory();

                switch (inv.Category)
                {
                    case "Goods":
                    case "Medication":
                        vmInventory.CategoryID = 5; // Misc item
                        break;
                    case "Vaccination":
                        vmInventory.CategoryID = 1; // Service item
                        break;
                    default:
                        vmInventory.CategoryID = 5; // Misc item
                        break;
                }


                vmInventory.TaxID = 1;


                vmInventory.UnitID = 1;
                vmInventory.ScheduleID = inv.Schedule + 1;

                if (inv.Description != null)
                    vmInventory.Description = inv.Description;
                else
                    continue;

                vmInventory.Code = inv.Code.ToString(); // Make sure about the inventory id
                vmInventory.BarCode = string.Empty;
                vmInventory.Grouped = false;
                vmInventory.ItemPricing = false;
                vmInventory.ShowItems = false;
                vmInventory.ShowItemPricing = false;

                vmInventory.UnitPriceExclusive = (decimal)inv.Cost;
                vmInventory.SellingPriceInclusive = (decimal)inv.Price;


                vmInventory.MarkUp = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingPriceExclusive = 0; // We will automatically calculate this in vetmaster
                vmInventory.SellingTaxAmount = 0; // We will automatically calculate this in vetmaster

                if (vmInventory.CategoryID != 1)
                    vmInventory.TrackLevels = true;
                else
                    vmInventory.TrackLevels = false;

                vmInventory.ReOrderLevel = 1;
                vmInventory.MaxLevel = 2;
                vmInventory.OnHand = 0;
                vmInventory.Discontinued = false;
                vmInventory.Comment = string.Empty;
                vmInventory.DosageInterval = string.Empty;
                vmInventory.OrderFactor = 1;
                vmInventory.FactorName = inv.UnitOfMeasure;
                vmInventory.CreateDate = DateTime.Now;
                vmInventory.CreateSaleReminder = false;
                vmInventory.ReminderMessage = string.Empty;
                vmInventory.ReminderDays = 0;
                vmInventory.ReminderLeadDays = 0;
                vmInventory.ApplyLoyalty = true;
                vmInventory.Created = DateTime.Now;
                vmInventory.Modified = DateTime.Now;
                vmInventory.RowVersion = 1;
                vmInventory.BranchID = 1;
                vmInventory.CheckBatch = false;

                myVetmasterDB.Inventories.InsertOnSubmit(vmInventory);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void convertInventory()
        {
            // Insert a New TaxRate
            InsertTaxRate();

            // Convert Proc
            ConvertProc();

            // Convert Consult
            ConvertConsult();

            // Convert Lab
            ConvertLab();

            // Convert Hospital
            ConvertHospital();

            // Convert Injection
            ConvertInjection();

            // Convert Vaccination
            ConvertVaccination();






            // ******************* START CONVERTING MISCELLANEOUS ITEMS ******************* //

            // Convert Diagnosis
            ConvertDiagnosis();

            // Convert Goods
            ConvertGoods();

            // Convert Medication
            ConvertMedication();

            // Convert StockTraceItem
            ConvertStockTraceItem();




            // ******************* INSERT ADJUSTMENT STATEMENTS ******************* //
            inventoryCounter = 0;

            var invs = myVetmasterDB.Inventories;

            totalInventory = invs.Count();

            foreach(var inv in invs)
            {
                // Insert into adjust table
                Adjustment vmAdjust = new Adjustment();
                vmAdjust.InventoryID = inv.ID;
                vmAdjust.ReasonID = 1;
                vmAdjust.BatchID = 0;
                vmAdjust.PurchaseOrderDetailID = 0;
                vmAdjust.Qty = 0;
                vmAdjust.AdjustDate = DateTime.Now;
                vmAdjust.UserID = 2;
                vmAdjust.Reference = "Dataconversion Entry";
                vmAdjust.Comment = string.Empty;
                vmAdjust.Created = DateTime.Now;
                vmAdjust.Modified = DateTime.Now;
                vmAdjust.RowVersion = 1;

                myVetmasterDB.Adjustments.InsertOnSubmit(vmAdjust);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++inventoryCounter * 100 / totalInventory; // counter is incremented for the next iteration
                backgroundWorkerInventory.ReportProgress(progressPercentage);
            }
        }

        private void convertPatientWeight()
        {
            patientWeightCounter = 0;
            var patientWeights = from patw in myCyberDB.patients
                                 where patw.Weight != null && patw.Weight != 0
                                 select patw;

            var patients = from patient in myVetmasterDB.Patients
                           select patient;

            totalPatientWeight = patientWeights.Count();

            foreach (var patient in patientWeights)
            {
                Linq.Weight vmWeight = new Weight();

                var myPatient = patients.Where(i => i.Location == patient.PetNumber.ToString()).FirstOrDefault();
                if (myPatient == null)
                {
                    patientWeightCounter++;
                    continue;
                }

                vmWeight.PatientID = myPatient.ID;
                vmWeight.WeighDate = DateTime.Now;
                vmWeight.Weight1 = (decimal)patient.Weight;
                vmWeight.Comment = string.Empty;
                vmWeight.Created = DateTime.Now;
                vmWeight.Modified = DateTime.Now;
                vmWeight.RowVersion = 1;

                myVetmasterDB.Weights.InsertOnSubmit(vmWeight);
                myVetmasterDB.SubmitChanges();

                progressPercentage = ++patientWeightCounter * 100 / totalPatientWeight; // counter is incremented for the next iteration
                backgroundWorkerPatientWeight.ReportProgress(progressPercentage);

            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            lblCustomerStatus.Text = "Busy";
            lblPatientStatus.Text = "Not Started";
            lblBalanceStatus.Text = "Not Started";
            lblPatientNoteStatus.Text = "Not Started";
            lblPatientWeightStatus.Text = "Not Started";
            lblInventoryStatus.Text = "Not Started";
            lblStatus.Text = "Processing...Please wait...";


            if (!backgroundWorkerCustomer.IsBusy)
                backgroundWorkerCustomer.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCustomer.IsBusy)
                backgroundWorkerCustomer.CancelAsync();
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertCustomers();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcCustomers.EditValue = e.ProgressPercentage;
            lblCustomerProgress.Text = counter + "/" + totalCustomers;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerCustomer.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblCustomerStatus.Text = "Completed!";
                lblBalanceStatus.Text = "Busy";
                if (!backgroundWorkerBalance.IsBusy)
                    backgroundWorkerBalance.RunWorkerAsync();
            }
        }

        private void backgroundWorkerPatient_DoWork(object sender, DoWorkEventArgs e)
        {
            convertPatients();
        }

        private void backgroundWorkerBalance_DoWork(object sender, DoWorkEventArgs e)
        {
            convertBalances();
        }

        private void backgroundWorkerPatientNote_DoWork(object sender, DoWorkEventArgs e)
        {
            convertPatientNotes();
        }

        private void backgroundWorkerInventory_DoWork(object sender, DoWorkEventArgs e)
        {
            convertInventory();
        }

        private void backgroundWorkerPatientWeight_DoWork(object sender, DoWorkEventArgs e)
        {
            convertPatientWeight();
        }

        private void backgroundWorkerPatientWeight_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcPatientWeight.EditValue = e.ProgressPercentage;
            lblPatientWeightProgress.Text = patientWeightCounter + "/" + totalPatientWeight;
        }

        private void backgroundWorkerPatientWeight_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerPatientWeight.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblPatientWeightStatus.Text = "Completed!";
                lblPatientNoteStatus.Text = "Busy";
                if (!backgroundWorkerPatientNote.IsBusy)
                    backgroundWorkerPatientNote.RunWorkerAsync();
            }
        }

        private void backgroundWorkerInventory_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcInventory.EditValue = e.ProgressPercentage;
            lblInventoryProgress.Text = inventoryCounter + "/" + totalInventory;
        }

        private void backgroundWorkerInventory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerInventory.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblInventoryStatus.Text = "Completed!";
                lblStatus.Text = "Conversion Completed";
                //if (!backgroundWorkerInventory.IsBusy)
                //    backgroundWorkerInventory.RunWorkerAsync();
            }
        }

        private void backgroundWorkerPatientNote_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcPatientNotes.EditValue = e.ProgressPercentage;
            lblPatientNoteProgress.Text = patientNoteCounter + "/" + totalPatientNotes;
        }

        private void backgroundWorkerPatientNote_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerPatientNote.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblPatientNoteStatus.Text = "Completed!";
                lblInventoryStatus.Text = "Busy";
                if (!backgroundWorkerInventory.IsBusy)
                    backgroundWorkerInventory.RunWorkerAsync();
            }
        }

        private void backgroundWorkerBalance_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcBalances.EditValue = e.ProgressPercentage;
            lblBalanceProgress.Text = balanceCounter + "/" + totalBalances;
        }

        private void backgroundWorkerBalance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerBalance.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblBalanceStatus.Text = "Completed!";
                lblPatientStatus.Text = "Busy";
                if (!backgroundWorkerPatient.IsBusy)
                    backgroundWorkerPatient.RunWorkerAsync();
            }
        }

        private void backgroundWorkerPatient_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbcPatients.EditValue = e.ProgressPercentage;
            lblPatientProgress.Text = patientCounter + "/" + totalPatients;
        }

        private void backgroundWorkerPatient_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorkerPatient.CancelAsync();
                lblStatus.Text = "Operation Cancelled";
            }
            else if (e.Error != null)
                lblStatus.Text = "Error: " + e.Error.Message;
            else
            {
                lblPatientStatus.Text = "Completed!";
                lblPatientWeightStatus.Text = "Busy";
                if (!backgroundWorkerPatientWeight.IsBusy)
                    backgroundWorkerPatientWeight.RunWorkerAsync();
            }
        }
    }
}