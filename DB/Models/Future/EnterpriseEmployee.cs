﻿using System;
using System.Collections.Generic;

namespace ACM.Models
{
    public partial class EnterpriseEmployee
    {
        public Guid EnterpriseEmployeeId { get; set; }
        public int EmpId { get; set; }
        public int Password { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string MiddleInitial { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? UserInfo { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Phone { get; set; }
        public byte[]? Ssn { get; set; }
        public bool FirstByteFlags { get; set; }
        public bool BtnMnt { get; set; }
        public bool CshrMnt { get; set; }
        public bool ClsMnt { get; set; }
        public bool CpnMnt { get; set; }
        public bool CustMnt { get; set; }
        public bool CmcanVw { get; set; }
        public bool CmcanAdj { get; set; }
        public bool CmcanClr { get; set; }
        public bool BackOffice { get; set; }
        public bool DptMnt { get; set; }
        public bool DrkMnt { get; set; }
        public bool DscMnt { get; set; }
        public bool EmpMnt { get; set; }
        public bool EmadjTips { get; set; }
        public bool ChgEmpCls { get; set; }
        public bool EmcshDwrs { get; set; }
        public bool EmpayRates { get; set; }
        public bool EmsecLvl { get; set; }
        public bool Emtmcrd { get; set; }
        public bool Empasswd { get; set; }
        public bool Fdmnt { get; set; }
        public bool Gcmnt { get; set; }
        public bool Gcissue { get; set; }
        public bool Gcdestroy { get; set; }
        public bool Gclist { get; set; }
        public bool HlpMnt { get; set; }
        public bool IngMnt { get; set; }
        public bool Igmadj { get; set; }
        public bool ItmMnt { get; set; }
        public bool ImadjPrc { get; set; }
        public bool MedMnt { get; set; }
        public bool MsgMnt { get; set; }
        public bool PckLoan { get; set; }
        public bool PrcSchd { get; set; }
        public bool PresMod { get; set; }
        public bool ReasMnt { get; set; }
        public bool RegMnt { get; set; }
        public bool ResMnt { get; set; }
        public bool Rsmnt { get; set; }
        public bool SchMnt { get; set; }
        public bool SpcMnt { get; set; }
        public bool TaxMnt { get; set; }
        public bool TblMnt { get; set; }
        public bool VndMnt { get; set; }
        public bool ActRpt { get; set; }
        public bool ChgInv { get; set; }
        public bool CoupRpt { get; set; }
        public bool Csrpt { get; set; }
        public bool CustLoyal { get; set; }
        public bool DscRpt { get; set; }
        public bool DupCrpt { get; set; }
        public bool Ecrpt { get; set; }
        public bool Ejrpt { get; set; }
        public bool EmProRpt { get; set; }
        public bool EmSlsRpt { get; set; }
        public bool EmTpsRpt { get; set; }
        public bool Icrpt { get; set; }
        public bool Iptrpt { get; set; }
        public bool Lvsrpt { get; set; }
        public bool MovRpt { get; set; }
        public bool PdOutRpt { get; set; }
        public bool ReordRpt { get; set; }
        public bool CmSlsRpt { get; set; }
        public bool SlsAcRpt { get; set; }
        public bool SlsRgRpt { get; set; }
        public bool SlsStRpt { get; set; }
        public bool Tbrpt { get; set; }
        public bool Tcrpt { get; set; }
        public bool Virpt { get; set; }
        public bool WageRpt { get; set; }
        public bool WkMvRpt { get; set; }
        public bool EntEmpMnt { get; set; }
        public bool Eemsecurity { get; set; }
        public bool EntSet { get; set; }
        public bool Sbrgrph { get; set; }
        public bool StoreRgn { get; set; }
        public bool LastByteFlags { get; set; }
        public bool Brrpt { get; set; }
        public bool Swarpt { get; set; }
        public bool ZoneMnt { get; set; }
        public bool RcslsRpt { get; set; }
        public bool IsInactive { get; set; }
        public bool BrkMnt { get; set; }
        public bool LogRpt { get; set; }
        public bool EditDashboards { get; set; }
        public bool AddDashPanel { get; set; }
        public bool EditFavorites { get; set; }
        public bool EntSbr { get; set; }
        public bool AdDriverMnt { get; set; }
        public bool SlsPdRpt { get; set; }
        public bool Sprpt { get; set; }
        public bool Dbsetup { get; set; }
        public bool LicenseFuturePos { get; set; }
        public bool FoodCostRpt { get; set; }
        public bool EntSync { get; set; }
        public bool CustChrgRpt { get; set; }
        public bool CashReconMnt { get; set; }
        public bool MnuMnt { get; set; }
        public bool BackupMnt { get; set; }
        public bool CashOvrShortRpt { get; set; }
        public bool NetInstall { get; set; }
        public bool AlertMnt { get; set; }
        public bool Isrpt { get; set; }
        public bool? AbraPayroll { get; set; }
        public bool? Accardis { get; set; }
        public bool? Adppayroll { get; set; }
        public bool? Apspayroll { get; set; }
        public bool? Cbspayroll { get; set; }
        public bool? ChefTec { get; set; }
        public bool? CostGuard { get; set; }
        public bool? DeductIt { get; set; }
        public bool? FoodTrak { get; set; }
        public bool? GreatPlainsGl { get; set; }
        public bool? GreatPlainsPayroll { get; set; }
        public bool? HeartlandPayroll { get; set; }
        public bool? Mas90Gl { get; set; }
        public bool? Mas90Payroll { get; set; }
        public bool? MenuLinkGl { get; set; }
        public bool? MenuLinkPayroll { get; set; }
        public bool? MenuLinkSalesInterval { get; set; }
        public bool? MenuLink { get; set; }
        public bool? PayChexPayroll { get; set; }
        public bool? PeachtreeGl { get; set; }
        public bool? QuickbooksGl { get; set; }
        public bool? QuickBooksPayroll { get; set; }
        public bool? SaaShrPayroll { get; set; }
        public bool? EnterpriseBulkDownloader { get; set; }
        public bool? WinSched { get; set; }
        public bool? Wsexprt { get; set; }
        public bool? Wsimprt { get; set; }
        public bool DinePointDump { get; set; }
        public bool? PurgeOldData { get; set; }
        public bool? ResetDatabase { get; set; }
        public bool? ServiceManager { get; set; }
        public bool? Gcreconciliation { get; set; }
        public bool? EntIcrpt { get; set; }
        public bool? EntFrontEnd { get; set; }
        public bool? EndofDay { get; set; }
        public bool EffectiveWageRpt { get; set; }
        public bool TipPoolMnt { get; set; }
        public bool PagerDriver { get; set; }
        public bool PagerMaint { get; set; }
        public bool DailySalesByMonthReport { get; set; }
        public bool MobileRegistration { get; set; }
        public bool CmviewLoyalty { get; set; }
        public bool Mas90EmployeeWage { get; set; }
        public bool InventoryList { get; set; }
        public bool AdjMeals { get; set; }
        public bool CmcanEditCc { get; set; }
        public bool CustCanEditFd { get; set; }
        public bool CustCanEditUserData { get; set; }
        public bool EmpcanChgBopass { get; set; }
        public bool ImcanDelete { get; set; }
        public bool EjrptCanViewCcs { get; set; }
        public bool CanResetActFile { get; set; }
        public bool EnterpriseBulkUploader { get; set; }
        public bool GenericPayroll { get; set; }
        public bool CustomerTransaction { get; set; }
        public bool ComparativeItemSales { get; set; }
        public bool QuickBooksExport { get; set; }
        public bool ScheduledUpdateMaintenance { get; set; }
        public bool SumcanDelete { get; set; }
        public bool SalesPerformance { get; set; }
        public bool ItemSales { get; set; }
        public bool DataGroupMaintenance { get; set; }
        public byte[]? EncryptedPassword { get; set; }
        public bool? NeedPasswordEncryption { get; set; }
        public bool EemcanEditPassword { get; set; }
        public bool StoreAccountabilityReport { get; set; }
        public bool ItemSize { get; set; }
        public bool ItemSizeDelete { get; set; }
        public byte[]? Salt { get; set; }
        public byte[]? BackOfficeHash { get; set; }
        public bool ResourceManager { get; set; }
    }
}