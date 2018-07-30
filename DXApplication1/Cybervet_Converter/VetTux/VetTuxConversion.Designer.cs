namespace VetTux_Converter.VetTux
{
    partial class frmVetTuxConversion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConvert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorkerCustomer = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.pbcCustomers = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblCustomerProgress = new DevExpress.XtraEditors.LabelControl();
            this.pbcPatients = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblPatientProgress = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorkerPatient = new System.ComponentModel.BackgroundWorker();
            this.lblCustomerStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pbcPatientNotes = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblPatientNoteProgress = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientNoteStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pbcInventory = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblInventoryProgress = new DevExpress.XtraEditors.LabelControl();
            this.lblInventoryStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.pbcBalances = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblBalanceProgress = new DevExpress.XtraEditors.LabelControl();
            this.lblBalanceStatus = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorkerBalance = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPatientNote = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInventory = new System.ComponentModel.BackgroundWorker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.pbcPatientWeight = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblPatientWeightProgress = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientWeightStatus = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorkerPatientWeight = new System.ComponentModel.BackgroundWorker();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbcCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatientNotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcInventory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcBalances.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatientWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(57, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Customers:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 129);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Patients:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(57, 349);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(175, 72);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(432, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 72);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // backgroundWorkerCustomer
            // 
            this.backgroundWorkerCustomer.WorkerReportsProgress = true;
            this.backgroundWorkerCustomer.WorkerSupportsCancellation = true;
            this.backgroundWorkerCustomer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorkerCustomer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorkerCustomer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(111, 278);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // pbcCustomers
            // 
            this.pbcCustomers.Location = new System.Drawing.Point(140, 70);
            this.pbcCustomers.Name = "pbcCustomers";
            this.pbcCustomers.Size = new System.Drawing.Size(187, 18);
            this.pbcCustomers.TabIndex = 2;
            // 
            // lblCustomerProgress
            // 
            this.lblCustomerProgress.Location = new System.Drawing.Point(196, 72);
            this.lblCustomerProgress.Name = "lblCustomerProgress";
            this.lblCustomerProgress.Size = new System.Drawing.Size(88, 13);
            this.lblCustomerProgress.TabIndex = 3;
            this.lblCustomerProgress.Text = "CustomerProgress";
            // 
            // pbcPatients
            // 
            this.pbcPatients.Location = new System.Drawing.Point(140, 128);
            this.pbcPatients.Name = "pbcPatients";
            this.pbcPatients.Size = new System.Drawing.Size(187, 18);
            this.pbcPatients.TabIndex = 2;
            // 
            // lblPatientProgress
            // 
            this.lblPatientProgress.Location = new System.Drawing.Point(196, 130);
            this.lblPatientProgress.Name = "lblPatientProgress";
            this.lblPatientProgress.Size = new System.Drawing.Size(76, 13);
            this.lblPatientProgress.TabIndex = 3;
            this.lblPatientProgress.Text = "PatientProgress";
            // 
            // backgroundWorkerPatient
            // 
            this.backgroundWorkerPatient.WorkerReportsProgress = true;
            this.backgroundWorkerPatient.WorkerSupportsCancellation = true;
            this.backgroundWorkerPatient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPatient_DoWork);
            this.backgroundWorkerPatient.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPatient_ProgressChanged);
            this.backgroundWorkerPatient.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPatient_RunWorkerCompleted);
            // 
            // lblCustomerStatus
            // 
            this.lblCustomerStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCustomerStatus.Location = new System.Drawing.Point(333, 75);
            this.lblCustomerStatus.Name = "lblCustomerStatus";
            this.lblCustomerStatus.Size = new System.Drawing.Size(65, 13);
            this.lblCustomerStatus.TabIndex = 3;
            this.lblCustomerStatus.Text = "Not Started";
            // 
            // lblPatientStatus
            // 
            this.lblPatientStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPatientStatus.Location = new System.Drawing.Point(333, 133);
            this.lblPatientStatus.Name = "lblPatientStatus";
            this.lblPatientStatus.Size = new System.Drawing.Size(65, 13);
            this.lblPatientStatus.TabIndex = 3;
            this.lblPatientStatus.Text = "Not Started";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(57, 186);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Patient Notes:";
            // 
            // pbcPatientNotes
            // 
            this.pbcPatientNotes.Location = new System.Drawing.Point(140, 185);
            this.pbcPatientNotes.Name = "pbcPatientNotes";
            this.pbcPatientNotes.Size = new System.Drawing.Size(187, 18);
            this.pbcPatientNotes.TabIndex = 2;
            // 
            // lblPatientNoteProgress
            // 
            this.lblPatientNoteProgress.Location = new System.Drawing.Point(196, 187);
            this.lblPatientNoteProgress.Name = "lblPatientNoteProgress";
            this.lblPatientNoteProgress.Size = new System.Drawing.Size(99, 13);
            this.lblPatientNoteProgress.TabIndex = 3;
            this.lblPatientNoteProgress.Text = "PatientNoteProgress";
            // 
            // lblPatientNoteStatus
            // 
            this.lblPatientNoteStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPatientNoteStatus.Location = new System.Drawing.Point(333, 190);
            this.lblPatientNoteStatus.Name = "lblPatientNoteStatus";
            this.lblPatientNoteStatus.Size = new System.Drawing.Size(65, 13);
            this.lblPatientNoteStatus.TabIndex = 3;
            this.lblPatientNoteStatus.Text = "Not Started";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(57, 215);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Inventory:";
            // 
            // pbcInventory
            // 
            this.pbcInventory.Location = new System.Drawing.Point(140, 214);
            this.pbcInventory.Name = "pbcInventory";
            this.pbcInventory.Size = new System.Drawing.Size(187, 18);
            this.pbcInventory.TabIndex = 2;
            // 
            // lblInventoryProgress
            // 
            this.lblInventoryProgress.Location = new System.Drawing.Point(196, 216);
            this.lblInventoryProgress.Name = "lblInventoryProgress";
            this.lblInventoryProgress.Size = new System.Drawing.Size(90, 13);
            this.lblInventoryProgress.TabIndex = 3;
            this.lblInventoryProgress.Text = "InventoryProgress";
            // 
            // lblInventoryStatus
            // 
            this.lblInventoryStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInventoryStatus.Location = new System.Drawing.Point(333, 219);
            this.lblInventoryStatus.Name = "lblInventoryStatus";
            this.lblInventoryStatus.Size = new System.Drawing.Size(65, 13);
            this.lblInventoryStatus.TabIndex = 3;
            this.lblInventoryStatus.Text = "Not Started";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 99);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Balances:";
            // 
            // pbcBalances
            // 
            this.pbcBalances.Location = new System.Drawing.Point(140, 98);
            this.pbcBalances.Name = "pbcBalances";
            this.pbcBalances.Size = new System.Drawing.Size(187, 18);
            this.pbcBalances.TabIndex = 2;
            // 
            // lblBalanceProgress
            // 
            this.lblBalanceProgress.Location = new System.Drawing.Point(196, 100);
            this.lblBalanceProgress.Name = "lblBalanceProgress";
            this.lblBalanceProgress.Size = new System.Drawing.Size(79, 13);
            this.lblBalanceProgress.TabIndex = 3;
            this.lblBalanceProgress.Text = "BalanceProgress";
            // 
            // lblBalanceStatus
            // 
            this.lblBalanceStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBalanceStatus.Location = new System.Drawing.Point(333, 103);
            this.lblBalanceStatus.Name = "lblBalanceStatus";
            this.lblBalanceStatus.Size = new System.Drawing.Size(65, 13);
            this.lblBalanceStatus.TabIndex = 3;
            this.lblBalanceStatus.Text = "Not Started";
            // 
            // backgroundWorkerBalance
            // 
            this.backgroundWorkerBalance.WorkerReportsProgress = true;
            this.backgroundWorkerBalance.WorkerSupportsCancellation = true;
            this.backgroundWorkerBalance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBalance_DoWork);
            this.backgroundWorkerBalance.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerBalance_ProgressChanged);
            this.backgroundWorkerBalance.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBalance_RunWorkerCompleted);
            // 
            // backgroundWorkerPatientNote
            // 
            this.backgroundWorkerPatientNote.WorkerReportsProgress = true;
            this.backgroundWorkerPatientNote.WorkerSupportsCancellation = true;
            this.backgroundWorkerPatientNote.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPatientNote_DoWork);
            this.backgroundWorkerPatientNote.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPatientNote_ProgressChanged);
            this.backgroundWorkerPatientNote.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPatientNote_RunWorkerCompleted);
            // 
            // backgroundWorkerInventory
            // 
            this.backgroundWorkerInventory.WorkerReportsProgress = true;
            this.backgroundWorkerInventory.WorkerSupportsCancellation = true;
            this.backgroundWorkerInventory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInventory_DoWork);
            this.backgroundWorkerInventory.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerInventory_ProgressChanged);
            this.backgroundWorkerInventory.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInventory_RunWorkerCompleted);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(57, 157);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Patient Weight:";
            // 
            // pbcPatientWeight
            // 
            this.pbcPatientWeight.Location = new System.Drawing.Point(140, 156);
            this.pbcPatientWeight.Name = "pbcPatientWeight";
            this.pbcPatientWeight.Size = new System.Drawing.Size(187, 18);
            this.pbcPatientWeight.TabIndex = 2;
            // 
            // lblPatientWeightProgress
            // 
            this.lblPatientWeightProgress.Location = new System.Drawing.Point(196, 158);
            this.lblPatientWeightProgress.Name = "lblPatientWeightProgress";
            this.lblPatientWeightProgress.Size = new System.Drawing.Size(110, 13);
            this.lblPatientWeightProgress.TabIndex = 3;
            this.lblPatientWeightProgress.Text = "PatientWeightProgress";
            // 
            // lblPatientWeightStatus
            // 
            this.lblPatientWeightStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPatientWeightStatus.Location = new System.Drawing.Point(333, 161);
            this.lblPatientWeightStatus.Name = "lblPatientWeightStatus";
            this.lblPatientWeightStatus.Size = new System.Drawing.Size(65, 13);
            this.lblPatientWeightStatus.TabIndex = 3;
            this.lblPatientWeightStatus.Text = "Not Started";
            // 
            // backgroundWorkerPatientWeight
            // 
            this.backgroundWorkerPatientWeight.WorkerReportsProgress = true;
            this.backgroundWorkerPatientWeight.WorkerSupportsCancellation = true;
            this.backgroundWorkerPatientWeight.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPatientWeight_DoWork);
            this.backgroundWorkerPatientWeight.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPatientWeight_ProgressChanged);
            this.backgroundWorkerPatientWeight.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPatientWeight_RunWorkerCompleted);
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "OWNERINF\r\nOWNERS\r\nPATHIST\r\nPATIENTS\r\nQUEINFO\r\nSTOCKCAT\r\nSTOCKCS\r\nSTOCKINF\r\nTITLE";
            this.memoEdit1.Location = new System.Drawing.Point(469, 98);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(168, 134);
            this.memoEdit1.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(469, 72);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(89, 13);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Required tables";
            // 
            // frmVetTuxConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 468);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.lblInventoryStatus);
            this.Controls.Add(this.lblPatientWeightStatus);
            this.Controls.Add(this.lblPatientNoteStatus);
            this.Controls.Add(this.lblBalanceStatus);
            this.Controls.Add(this.lblPatientStatus);
            this.Controls.Add(this.lblInventoryProgress);
            this.Controls.Add(this.lblPatientWeightProgress);
            this.Controls.Add(this.lblPatientNoteProgress);
            this.Controls.Add(this.lblBalanceProgress);
            this.Controls.Add(this.lblPatientProgress);
            this.Controls.Add(this.pbcPatientWeight);
            this.Controls.Add(this.pbcInventory);
            this.Controls.Add(this.pbcPatientNotes);
            this.Controls.Add(this.pbcBalances);
            this.Controls.Add(this.pbcPatients);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lblCustomerStatus);
            this.Controls.Add(this.lblCustomerProgress);
            this.Controls.Add(this.pbcCustomers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmVetTuxConversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VetTux Conversion";
            ((System.ComponentModel.ISupportInitialize)(this.pbcCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatientNotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcInventory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcBalances.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPatientWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConvert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCustomer;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ProgressBarControl pbcCustomers;
        private DevExpress.XtraEditors.LabelControl lblCustomerProgress;
        private DevExpress.XtraEditors.ProgressBarControl pbcPatients;
        private DevExpress.XtraEditors.LabelControl lblPatientProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPatient;
        private DevExpress.XtraEditors.LabelControl lblCustomerStatus;
        private DevExpress.XtraEditors.LabelControl lblPatientStatus;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ProgressBarControl pbcPatientNotes;
        private DevExpress.XtraEditors.LabelControl lblPatientNoteProgress;
        private DevExpress.XtraEditors.LabelControl lblPatientNoteStatus;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ProgressBarControl pbcInventory;
        private DevExpress.XtraEditors.LabelControl lblInventoryProgress;
        private DevExpress.XtraEditors.LabelControl lblInventoryStatus;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ProgressBarControl pbcBalances;
        private DevExpress.XtraEditors.LabelControl lblBalanceProgress;
        private DevExpress.XtraEditors.LabelControl lblBalanceStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBalance;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPatientNote;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInventory;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ProgressBarControl pbcPatientWeight;
        private DevExpress.XtraEditors.LabelControl lblPatientWeightProgress;
        private DevExpress.XtraEditors.LabelControl lblPatientWeightStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPatientWeight;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}